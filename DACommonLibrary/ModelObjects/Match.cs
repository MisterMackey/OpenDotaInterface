using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DACommonLibrary.ModelObjects
{
    /// <summary>
    /// represents a dota 2 match, contains top level info like ID, duration, picks, players etc.
    /// </summary>
    public class Match 
    {
        //properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 match_id { get; set; }
        public int barracks_status_dire { get; set; }
        public int barracks_status_radiant { get; set; }
        public int dire_score { get; set; }
        public List<DraftTiming> draft_timings { get; set; }
        public int duration { get; set; }
        public int first_blood_time { get; set; }
        public int game_mode { get; set; }
        public int lobby_type { get; set; }
        public List<Objective> objectives { get; set; }
        public int[] radiant_gold_adv { get; set; }
        public int radiant_score { get; set; }
        public bool radiant_win { get; set; }
        public int[] radiant_xp_adv { get; set; }
        public int start_time { get; set; }
        public int number_teamfights { get; set; }
        public int tower_status_radiant { get; set; }
        public int tower_status_dire { get; set; }
        public List<Player> players { get; set; }
        public int patch { get; set; }
        public int region { get; set; }
        public string replay_url { get; set; }
        




        //tostring override
        public override string ToString()
        {
            PropertyInfo[] infos;
            infos = this.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            foreach (var info in infos)
            {
                if (info.Name.Equals("draft_timings"))
                {
                    sb.AppendLine("draft_timings: ");
                    foreach (DraftTiming timing in this.draft_timings)
                    {
                        sb.AppendLine("\t {\n\t order: " + timing.order);
                        sb.AppendLine("\t pick: " + timing.pick);
                        sb.AppendLine("\t active_team: " + timing.active_team);
                        sb.AppendLine("\t hero_id" + timing.hero_id);
                        sb.AppendLine("\t player_slot" + timing.player_slot);
                        sb.AppendLine("\t extra_time: " + timing.extra_time);
                        sb.AppendLine("\t total_time_taken: " + timing.total_time_taken + "\n\t}");
                    }
                }
                else if (info.Name.Equals("objectives"))
                {
                    sb.AppendLine("objectives: ");
                    foreach (Objective timing in this.objectives)
                    {
                        sb.AppendLine("\t {\n\t time: " + timing.time);
                        sb.AppendLine("\t type: " + timing.type);
                        sb.AppendLine("\t unit: " + timing.unit);
                        sb.AppendLine("\t key: " + timing.key);
                        sb.AppendLine("\t player_slot: " + timing.player_slot + "\n\t}");
                    }
                }
                else if (info.Name.Equals("players" ))
                {
                    sb.AppendLine("players: ");
                    foreach (Player player in this.players)
                    {
                        sb.AppendLine(player.ToString());
                    }
                }
                else
                {
                    sb.AppendLine(info.Name + ":" + info.GetValue(this, null).ToString());
                }
            }
            return sb.ToString();
        }
    }
}
