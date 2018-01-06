using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// represents a single record in a matchdetail set. contains information about a specific hero pick in a match
    /// </summary>
    public class MatchDetailedRecord : WinrateAnalyzerDBObject
    {
        //properties
        public int      MatchId             { get; set; } //should be inherited from collection object
        public bool     IsPickedNotBanned   { get; set; }
        public bool     IsRandomed          { get; set; }
        public int      Order               { get; set; }
        public int      IsPickedOnRadiant   { get; set; }
        public int      HeroId              { get; set; }
        public int      NetWorth            { get; set; } //at match end
        public int      Experience          { get; set; }
        public int      Level               { get; set; }
        public int      PlayerId            { get; set; }
        public int      WardsPurchased      { get; set; }
        public int      SentriesPurchased   { get; set; }
        public int      CourierPurchased    { get; set; } //you know full well why this is an int and not a bool ;)
        public int      DustPurchased       { get; set; }
        public int      SmokePurchased      { get; set; }
        public int      GemPurchased        { get; set; }
        public int      Kills               { get; set; }
        public int      Deaths              { get; set; }
        public int      Assists             { get; set; }

        //insert method
        public override bool InsertRecord()
        {
            throw new NotImplementedException();
        }
    }
}
