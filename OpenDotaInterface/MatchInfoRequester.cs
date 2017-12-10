using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenDotaInterface
{
    /// <summary>
    /// contains methods to request match info from opendota
    /// </summary>
    public class MatchInfoRequester
    {
        //members
        private HttpClient HttpClient = new HttpClient();
        private string BaseAdress = "https://api.opendota.com/api/matches/";

        //constructor
        public MatchInfoRequester()
        {
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
        public async Task<string> GetJsonFormattedMatchInfo(int matchId)
        {
            string id = Convert.ToString(matchId);
            return await HttpClient.GetStringAsync(new Uri(HttpClient.BaseAddress + id));
        }
    }
}