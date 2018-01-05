using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDotaInterface.DBO;
using Newtonsoft.Json;
using System.IO;

namespace OpenDotaInterface
{
    /// <summary>
    /// contains methods to parse JSON files into DB records (implementation specific, no generic functions here)
    /// </summary>
    public class MatchInfoParser
    {
        //members
        MatchInfoRequester MatchInfoRequester;

        //constructor
        public MatchInfoParser()
        {
            this.MatchInfoRequester = new MatchInfoRequester();
        }

        /// <summary>
        /// parses the JSON information of a match
        /// </summary>
        /// <param name="matchId">the match to parse</param>
        /// <returns>List of objects ready to be inserted into DB</returns>
        public List<WinrateAnalyzerDBObject> ParseJSONMatchInfo(int matchId)
        {
            List<WinrateAnalyzerDBObject> ReturnValue = new List<WinrateAnalyzerDBObject>();
            try
            {
                //get the json 
                string JSON = MatchInfoRequester.GetJsonFormattedMatchInfo(matchId).Result;
                //parse the json
                using (JsonTextReader reader = new JsonTextReader(new StringReader(JSON)))
                {
                    //whelp, lets go for somewhat efficient DB connecting and buffer full DB objects before writing anything to sql.
                    //that means parsing an entire match before calling Insert
                    while (reader.Read())
                    {
                        //make config file with children to skip
                    }
                }
            }
            catch (Exception)
            {

            }

            return ReturnValue;
        }
    }
}
