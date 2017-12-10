using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// represents a dota 2 match, contains top level info like ID, duration, picks, players etc.
    /// </summary>
    public class Match : WinrateAnalyzerDBObject
    {
        //properties
        public int      MatchId                 { get; set; }
        public string   SkillBracket            { get; set; }
        public string   LobbyType               { get; set; }
        public string   GameMode                { get; set; }
        public string   Region                  { get; set; }
        public int      Duration                { get; set; } //duration in seconds
        public bool     RadiantIsVictorious     { get; set; } //0 --> dire won
        public int      RadiantKillCount        { get; set; }
        public int      DireKillCount           { get; set; }
        public int      RadiantAssistCount      { get; set; }
        public int      DireAssistCount         { get; set; }
        public int      RadiantDeathCount       { get; set; }
        public int      RadiantGoldEarned       { get; set; }
        public int      DireDeathCount          { get; set; }
        public int      DireGoldEarned          { get; set; }
        public int      RadiantExperienceEarned { get; set; }
        public int      DireExperienceEarned    { get; set; }
        public string   ChatLog                 { get; set; }
        public DateTime MatchEndingDateTime     { get; set; }


        //insert method
        public override bool InsertRecord()
        {
            
            try
            {

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                
            }
        }
    }
}
