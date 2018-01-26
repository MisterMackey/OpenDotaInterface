using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using System.Timers;

namespace OpenDotaInterface
{
    /// <summary>
    /// contains methods to request match info from opendota
    /// </summary>
    public class MatchInfoRequester :IDisposable
    {
        //members
        private HttpClient HttpClient;
        private string BaseAdress = "https://api.opendota.com/api/matches/";
        private Timer Timer;
        private bool TimerElapsed;
        private bool IsThrottled;
        //constructor
        public MatchInfoRequester()
        {
            bool UseFiddlerProxy = bool.Parse(ConfigurationManager.AppSettings.GetValues("UseFiddlerProxy")[0]);
            if (UseFiddlerProxy == true)
            {
                HttpClientHandler httpClienthandler = new HttpClientHandler();
                httpClienthandler.UseProxy = true;
                httpClienthandler.Proxy = new WebProxy("http://127.0.0.1:8888");
                HttpClient = new HttpClient(httpClienthandler);
            }
            else
            {
                HttpClient = new HttpClient();
            }
            HttpClient.BaseAddress = new Uri(BaseAdress);
            IsThrottled = false;
        }
        /// <summary>
        /// initializes a matchrequester that is throttled to only request at a maximum speed of x seconds
        /// </summary>
        /// <param name="MaxRequestsPerSecond">the maximum amount of requests per second</param>
        public MatchInfoRequester(int MaxRequestsPerSecond) : base()
        {
            double Timeout = 1000 / MaxRequestsPerSecond - 50; //i subtract 50 milliseconds because overhead takes time too. the value 50 i just pulled out of my arse :)
            if (Timeout < 0 ) { IsThrottled = false; } //if we have no timeout we are essentially running in non-throttled mode
            Timer = new Timer(MaxRequestsPerSecond);
            TimerElapsed = true;
            Timer.Elapsed += OnTimerElapsed;
            IsThrottled = true;
        }

        private void OnTimerElapsed(object e, EventArgs eventArgs)
        {
            TimerElapsed = true;
        }

        /// <summary>
        /// Gets match information of the match specified by matchId
        /// </summary>
        /// <param name="matchId">the Id of the match to get</param>
        /// <returns>Task object with a string representing the json formatted match info</string></returns>
        public async Task<string> GetJsonFormattedMatchInfo(string matchId)
        {
            return await HttpClient.GetStringAsync(new Uri(HttpClient.BaseAddress + matchId));
        }
        //overload that takes int argument
        public async Task<string> GetJsonFormattedMatchInfo(long matchId)
        {
                        string id = Convert.ToString(matchId);
            if (!IsThrottled)
            {
                return await HttpClient.GetStringAsync(new Uri(HttpClient.BaseAddress + id));
            }
            else
            {
                while (!TimerElapsed)
                {
                    System.Threading.Thread.Sleep(100);
                }
                return await HttpClient.GetStringAsync(new Uri(HttpClient.BaseAddress + id));
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    HttpClient.Dispose();
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MatchInfoRequester() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}