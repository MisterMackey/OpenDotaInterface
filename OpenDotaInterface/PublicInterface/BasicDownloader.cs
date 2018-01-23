﻿using System;
using System.ComponentModel.Composition;
using OpenDotaInterface.DBO;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OpenDotaInterface.PublicInterface
{
    /// <summary>
    /// exposes basic method to download a match with given ID and write it to DB
    /// </summary>
    [Export(typeof(IDotaMatchDownloader))]
    public sealed class BasicDownloader : IDotaMatchDownloader, IDisposable
    {
        //members to request json, parse it and write it to DB
        private MatchInfoRequester requester = new MatchInfoRequester();
        private MatchInfoWriter writer = new MatchInfoWriter();
        private DBObjectFactory factory = new DBObjectFactory();
        //some threading stuff goes here
        private List<Thread> DownloadThreadList = new List<Thread>(); // to keep track of the download
        private int ProcesserCount = Int32.Parse(Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS", EnvironmentVariableTarget.Machine));
        private ConcurrentQueue<Match> DownloadQueu = new ConcurrentQueue<Match>(); //aaaaw yiss, threadsafe collections boys

        public void Dispose()
        {
            ((IDisposable)requester).Dispose();
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
        /// MultiThread enabled method to download a range of matches. Ignores 404's
        /// </summary>
        /// <param name="lowestID"></param>
        /// <param name="highestID"></param>
        public void DownloadRange(long lowestID, long highestID)
        {
            int ThreadCount = ProcesserCount - 1; //the last cpu is for writing to DB, topkek
            long TotalCount = highestID - lowestID;
            //create the download threads and divide the matches over them
            
            for (int i = 0; i < ThreadCount; i++)
            {
                DownloadThreadClass threadClass = new DownloadThreadClass(DownloadQueu);
                threadClass.start = lowestID + i; // start at an offset of i
                threadClass.highest = highestID;
                threadClass.ThreadAmount = ThreadCount;
                Thread DownloadThread = new Thread(threadClass.DownloadThread);
                DownloadThread.IsBackground = true;
                DownloadThreadList.Add(DownloadThread);
            }
            //create a thread that reads from the queu and writes to DB
            WriterThreadClass writeClass = new WriterThreadClass(DownloadQueu, DownloadThreadList);
            Thread WriterThread = new Thread(writeClass.WriterThread);
            WriterThread.IsBackground = true;

            //start everything up
            foreach (var thr in DownloadThreadList)
            { thr.Start(); }
            WriterThread.Start();

        }

        private class DownloadThreadClass
        {
            public DownloadThreadClass(ConcurrentQueue<Match> match)
            { queuRef = match; }
            public long start { get; set; }
            public long highest { get; set; }
            public int ThreadAmount { get; set; }
            public ConcurrentQueue<Match> queuRef { get; set; } //reference to the shared queu
            public void DownloadThread()
            {
                //each thread has its own requester
                MatchInfoRequester requester = new MatchInfoRequester();
                //and its own parser 
                DBObjectFactory factory = new DBObjectFactory();
                //lets goooooo
                //logging statement: thread x starting to download
                
                //download pattern is as follows: if n = numthreads then the nth thread downloads matches n + k*n
                for (long i = start; i < highest; i += ThreadAmount )
                {
                    //logging statement here?
                    try
                    {
                        string json = requester.GetJsonFormattedMatchInfo(i).Result;
                        queuRef.Enqueue(factory.CreateMatchFromJson(json));
                    }
                    catch (Exception)
                    {
                        //logging statement: match not found
                    }
                }
            }
        }

        private class WriterThreadClass
        {
            public ConcurrentQueue<Match> QueuRef { get; set; }
            private MatchInfoWriter Writer { get; set; }
            private List<Thread> ThreadList { get; set; } //list containing refs to all the downloadthreads
            private List<Match> BufferList { get; set; }
            int MaxObjectBuffer = 100;
            public WriterThreadClass(ConcurrentQueue<Match> queuRef, List<Thread> downloadThreadList)
            {
                this.QueuRef = queuRef;
                this.ThreadList = downloadThreadList;
                this.Writer = new MatchInfoWriter();
                BufferList = new List<Match>();
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
                    BufferList.Clear(); //and reset it
                    //maybe raise an event here to let the client know about the progress?
                }
            }
        }

    }
}
