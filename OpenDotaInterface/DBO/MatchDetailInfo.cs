using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// represents lower level info (more detailed) of a match like hero picks, hero bans, order of picks/bans and the players playing them
    /// this class is essentially a collection of records, each record containing one hero pick and all information related to it
    /// </summary>
    public class MatchDetailInfo : WinrateAnalyzerDBObject
    {
        //properties
        public int MatchId { get; set; }
        public List<MatchDetailedRecord> PicksAndBans { get; set; }

        //insert method
        public override bool InsertRecord()
        {
            throw new NotImplementedException();
        }
    }
}
