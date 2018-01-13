using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// represents a dota 2 match, contains top level info like ID, duration, picks, players etc.
    /// </summary>
    public class Match : WinrateAnalyzerDBObject
    {
        //properties
        public Int64 match_id { get; set; }
        public int barracks_status_dire { get; set; }
        public int barracks_status_radiant { get; set; }
        public int dire_score { get; set; }
        public JArray draft_timings { get; set; }
        public int duration { get; set; }
        public int first_blood_time { get; set; }
        public int game_mode { get; set; }
        public int lobby_type { get; set; }
        public JArray objectives { get; set; }
        public int[] radiant_gold_adv { get; set; }
        public int radiant_score { get; set; }
        public bool radiant_win { get; set; }
        public int[] radiant_xp_adv { get; set; }
        public int start_time { get; set; }
        public int number_teamfights { get; set; }
        public int tower_status_radiant { get; set; }
        public int tower_status_dire { get; set; }
        public JArray players { get; set; }
        public int patch { get; set; }
        public int region { get; set; }
        public string replay_url { get; set; }
        

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

        //tostring override
        public override string ToString()
        {
            PropertyInfo[] infos;
            infos = this.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            foreach (var info in infos)
            {
                sb.AppendLine(info.Name + ":" + info.GetValue(this, null).ToString());
            }
            return sb.ToString();
        }
    }
}
