using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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

        //constructor
        public MatchInfoRequester()
        {
            HttpClientHandler httpClienthandler = new HttpClientHandler();
            httpClienthandler.UseProxy = true;
            httpClienthandler.Proxy = new WebProxy("http://127.0.0.1:8888");
            HttpClient = new HttpClient(httpClienthandler);
            HttpClient.BaseAddress = new Uri(BaseAdress);
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
            return await HttpClient.GetStringAsync(new Uri(HttpClient.BaseAddress + id));
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