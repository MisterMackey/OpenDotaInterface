using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDotaInterface.DBO;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OpenDotaInterface
{
    /// <summary>
    /// contains methods to parse JSON files into DB records (implementation specific, no generic functions here)
    /// </summary>
    [Obsolete("Use DBObjectFactory instead")]
    public class MatchInfoParser
    {
        //members
        MatchInfoRequester MatchInfoRequester;
        DBObjectFactory Factory;
        public JObject debug;
        public Match debugbuild;

        //constructor
        public MatchInfoParser()
        {
            this.MatchInfoRequester = new MatchInfoRequester();
            this.Factory = new DBObjectFactory();
            //some debug code
            SubParser Parser = new SubParser();
            SubBuilder Builder = new SubBuilder();
            Builder.Factory = Factory;
            string json = MatchInfoRequester.GetJsonFormattedMatchInfo("3607383684").Result;
            debug = Parser.Parse(json);
            debugbuild = (Match)Builder.Build(debug);
        }

        /// <summary>
        /// parses the JSON information of a match
        /// </summary>
        /// <param name="matchId">the match to parse</param>
        /// <returns>List of objects ready to be inserted into DB</returns>
        public List<WinrateAnalyzerDBObject> ParseJSONMatchInfo(int matchId)
        {
            throw new NotImplementedException();
        }
        //overload that straight up takes a string
        public List<WinrateAnalyzerDBObject> ParseJSONMatchInfo(string json)
        {
            throw new NotImplementedException();
        }


        //private subclasses that implement parsing and building the dbo objects
        
        //converts to a json object and trims out the excess data
        private class SubParser
        {
            public JObject Parse(string json)
            {
                List<string> WantedTokens = new List<string> { "match_id",
                                                                "barracks_status_dire" ,
                                                                "barracks_status_radiant" ,
                                                                "dire_score" ,
                                                                "draft_timings" ,
                                                                "duration" ,
                                                                "first_blood_time" ,
                                                                "game_mode" ,
                                                                "lobby_type" ,
                                                                "objectives" ,
                                                                "radiant_gold_adv" ,
                                                                "radiant_score" ,
                                                                "radiant_win" ,
                                                                "radiant_xp_adv" ,
                                                                "start_time" ,
                                                                "teamfights" ,
                                                                "tower_status_radiant" ,
                                                                "tower_status_dire" ,
                                                                "players" ,
                                                                "patch" ,
                                                                "region" ,
                                                                "replay_url"};
                //put the json into a JObject
                JObject MatchInfo = JObject.Parse(json);
                //why does this need a cast? im pretty sure the List class implements the IEnumerable interface....
                //anyway time to select the info we want see http://goessner.net/articles/JsonPath/ for infoz
                List<JToken> ReleventInfo = new List<JToken>();
                
                foreach (string token in WantedTokens)
                {
                    ReleventInfo.Add((MatchInfo.SelectToken("$." + token)));
                }
                MatchInfo.RemoveAll();
                foreach (JToken item in ReleventInfo)
                {
                    MatchInfo.Add(item.Path, item);
                }
                return MatchInfo;
            }


        }
        //makes calls to factory class to build final objects
        private class SubBuilder
        {
            public DBObjectFactory Factory;
            public WinrateAnalyzerDBObject Build(JObject resource)
            {
                return Factory.CreateObject(resource);
            }
        }
    }
}
