using System;
using System.ComponentModel.Composition;
using OpenDotaInterface.DBO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DACommonLibrary.Interfaces;
using DACommonLibrary.ModelObjects;
using System.Net;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace OpenDotaInterface.PublicInterface
{
    /// <summary>
    /// exposes download methods
    /// </summary>
    [Export(typeof(IDotaMatchDownloader))]
    public class BasicDownloader : IDotaMatchDownloader, IDisposable
    {
        #region members
        //members to request json, parse it and write it to DB
        protected MatchInfoRequester requester = new MatchInfoRequester();
        protected MatchInfoWriter writer = new MatchInfoWriter();
        protected DBObjectFactory factory = new DBObjectFactory();
        //some threading stuff goes here
        protected List<Thread> DownloadThreadList = new List<Thread>(); // to keep track of the download, remember to clear after its done
        protected int ProcesserCount = Int32.Parse(Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS", EnvironmentVariableTarget.Machine));
        protected ConcurrentQueue<Match> DownloadQueu = new ConcurrentQueue<Match>(); //aaaaw yiss, threadsafe collections boys
        //event handler stuff
        public event EventHandler<DownloaderEventArgs> DataWritten;
        public event Action DownloadIsFinished;
        //logging stuff
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        public void Dispose()
        {
            ((IDisposable)requester).Dispose();
        }

        protected void OnDownloadIsFinished()
        {
            Action handler = DownloadIsFinished;
            if (handler != null)
            {
                handler();
            }
        }
        protected void OnDataWritten(DownloaderEventArgs e)
        {
            EventHandler<DownloaderEventArgs> handler = DataWritten;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        /// <summary>
        /// does what it says on the box.
        /// </summary>
        /// <param name="match_id"></param>
        /// <returns></returns>
        public int Download(long match_id)
        {
            string json = requester.GetJsonFormattedMatchInfo(match_id).Result;
            Match match = factory.CreateMatchFromJson(json);
            int result = writer.Insert(match);
            return result;
        }

        /// <summary>
        /// MultiThread enabled method to download a range of matches. Ignores 404's, throttled to 3 downloads per second.
        /// </summary>
        /// <param name="lowestID"></param>
        /// <param name="highestID"></param>
        public void DownloadRange(long lowestID, long highestID)
        {
            int ThreadCount = (ProcesserCount - 1 > 3 ? 3 : ProcesserCount - 1); //really no point in having more than 3 threads.
            long TotalCount = highestID - lowestID;
            int MaxRequestsPerSecond = 3 / ThreadCount;
            //create the download threads and divide the matches over them
            
            for (int i = 0; i < ThreadCount; i++)
            {
                DownloadThreadClass threadClass = new DownloadThreadClass(DownloadQueu)
                { MaxRequestsPerSecond = MaxRequestsPerSecond};
                threadClass.start = lowestID + i; // start at an offset of i
                threadClass.highest = highestID;
                threadClass.ThreadAmount = ThreadCount;
                Thread DownloadThread = new Thread(threadClass.DownloadThread);
                DownloadThread.IsBackground = true;
                DownloadThreadList.Add(DownloadThread);
                log.Debug("Download thread created");
            }
            //create a thread that reads from the queu and writes to DB
            WriterThreadClass writeClass = new WriterThreadClass(DownloadQueu, DownloadThreadList, this);
            Thread WriterThread = new Thread(writeClass.WriterThread);
            WriterThread.IsBackground = true;
            log.Debug("writer thread created");

            //start everything up
            foreach (var thr in DownloadThreadList)
            { thr.Start(); }
            WriterThread.Start();
            log.Debug("Threads started");

        }

        protected class DownloadThreadClass
        {
            public DownloadThreadClass(ConcurrentQueue<Match> match)
            { queuRef = match; }
            public int MaxRequestsPerSecond { get; set; }
            public long start { get; set; }
            public long highest { get; set; }
            public int ThreadAmount { get; set; }
            public ConcurrentQueue<Match> queuRef { get; set; } //reference to the shared queu
            public void DownloadThread()
            {
                //each thread has its own requester
                MatchInfoRequester requester = new MatchInfoRequester(MaxRequestsPerSecond);
                //and its own parser 
                DBObjectFactory factory = new DBObjectFactory();
                //lets goooooo
                //logging statement: thread x starting to download
                
                //download pattern is as follows: if n = numthreads then the nth thread downloads matches n + k*n
                for (long i = start; i < highest; i += ThreadAmount )
                {
                    log.Info("Attempting to download match: " + i.ToString());
                    try
                    {
                        string json = requester.GetJsonFormattedMatchInfo(i).Result;
                        queuRef.Enqueue(factory.CreateMatchFromJson(json));
                    }
                    catch (AggregateException e)
                    {
                        //if its a httpexception caught inside an aggregate
                        if (e.InnerExceptions.Count == 1 && e.InnerExceptions[0].GetType() == typeof(System.Net.Http.HttpRequestException))
                        {
                            log.Info("Exception thrown when downloading match: " + i.ToString() + Environment.NewLine + e.InnerExceptions[0].Message);
                        }
                        else { throw; }
                    }

                }
            }
        }

        protected class WriterThreadClass
        {
            public ConcurrentQueue<Match> QueuRef { get; set; }
            protected BasicDownloader ReferenceToParent { get; set; } //to invoke event
            protected MatchInfoWriter Writer { get; set; }
            protected List<Thread> ThreadList { get; set; } //list containing refs to all the downloadthreads
            protected List<Match> BufferList { get; set; }
            int MaxObjectBuffer = 100;
            public WriterThreadClass(ConcurrentQueue<Match> queuRef, List<Thread> downloadThreadList, BasicDownloader reference)
            {
                this.QueuRef = queuRef;
                this.ThreadList = downloadThreadList;
                this.Writer = new MatchInfoWriter();
                BufferList = new List<Match>();
                this.ReferenceToParent = reference;
            }

            public void WriterThread()
            {
                //while download is ongoing : do while buffer < 100 do remove from queu and put in buffer till its @ 100 end write buffer to db; reset buffer end
                bool DownloadIsOngoing = ThreadList.Exists(x => x.IsAlive == true);
                while (DownloadIsOngoing) //while there is at least one thread executing
                {
                    while (DownloadIsOngoing && BufferList.Count() < MaxObjectBuffer) //while buffer is not max size AND download threads are open
                    {
                        Match match = new Match();
                        if (QueuRef.TryDequeue(out match))
                        {
                            BufferList.Add(match);
                        }
                        else
                        {
                            //if we fail to retrieve an item it might signal that the download is finished so we have to evaluate downloadisongoing
                            //in fact this is the only place we should re evaluate it, its kind of a hack but it ensures that we continue to write to
                            //db while there are items left in the queu even though the download can be done already
                            DownloadIsOngoing = ThreadList.Exists(x => x.IsAlive == true);
                        }
                    }
                    //bufferlist now has 100 items in it, time to write
                    Writer.InsertRange(BufferList);
                    //raise event
                    //technically not the highest id but should be close
                    ReferenceToParent.OnDataWritten(new DownloaderEventArgs() { AmountWritten = BufferList.Count, HighestMatchIdWritten = BufferList.Last().match_id });
                    log.Info("Wrote some matches, count is " + BufferList.Count.ToString());
                    BufferList.Clear(); //and reset it
                    
                }
                //raise event
                ReferenceToParent.OnDownloadIsFinished();
                //cleanup the threads
                ThreadList.Clear();
            }
        }

    }
}
