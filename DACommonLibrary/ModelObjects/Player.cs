using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DACommonLibrary.ModelObjects
{
    /// <summary>
    /// describes a single player in the players json
    /// </summary>
    public class Player
    {
        [Key]
        public int PlayerId { get; set; } //id use account_id but it can be null in source data.
        //foreign key
        public Int64 match_id { get; set; }
        public int player_slot { get; set; }
        public int[] ability_upgrades_arr { get; set; }
        public string account_id { get; set; }
        public int assists { get; set; }
        //note: below is not fed directly from json but is constructed by the factory using the "damage" path in the json, calculating the sum of its values
        //public int damage_dealt { get; set; }
        //note: below is not fed directly from json but is constructed by the factory using the "damage_taken" path in the json, calculating the sum of its values
        //public int damage_received { get; set; }
        public int deaths { get; set; }
        public int denies { get; set; }
        public int gold { get; set; } //this is gold in inventory at match end
        public int gold_per_min { get; set; }
        public int gold_spent { get; set; }
        public int hero_damage { get; set; }
        public int hero_healing { get; set; }
        public int hero_id { get; set; }
        public int item_0 { get; set; }
        public int item_1 { get; set; }
        public int item_2 { get; set; }
        public int item_3 { get; set; }
        public int item_4 { get; set; }
        public int item_5 { get; set; }
        public int kills { get; set; }
        public int last_hits { get; set; }
        public int level { get; set; }
        public int obs_placed { get; set; }
        public int party_size { get; set; }
        public bool pred_vict { get; set; }
        public bool randomed { get; set; }
        public int roshans_killed { get; set; }
        public int rune_pickups { get; set; }
        public int sen_placed { get; set; }
        public float teamfight_participation { get; set; }
        public int tower_damage { get; set; }
        public string personaname { get; set; }
        public bool isRadiant { get; set; }
        public int win { get; set; }
        public int lose { get; set; }
        public int total_gold { get; set; }
        public int total_xp { get; set; }
        public float kills_per_min { get; set; }
        public int lane { get; set; }
        public int lane_role { get; set; }
        public string rank_tier { get; set; }
        [NotMapped]
        public Benchmarks benchmarks { get; set; }
        //the following are filled in from the benchmarks object, which is not mapped to the DB but is included so allow the json deserializer to parse the values in
        //if value is not filled, the raw value inside benchmarks is used.
        public float xp_per_min { get { if (_xp_per_min == 0) { _xp_per_min = benchmarks.xp_per_min.raw; return _xp_per_min; } else { return _xp_per_min; } } set { _xp_per_min = value; } }
        public float last_hits_per_min { get { if (_last_hits_per_min == 0) { _last_hits_per_min = benchmarks.last_hits_per_min.raw; return _last_hits_per_min; } else { return _last_hits_per_min; } } set { _last_hits_per_min = value; } }
        public float hero_damage_per_min { get { if (_hero_damage_per_min == 0) { _hero_damage_per_min = benchmarks.hero_damage_per_min.raw; return _hero_damage_per_min; } else { return _hero_damage_per_min; } } set { _hero_damage_per_min = value; } }
        public float hero_healing_per_min { get { if (_hero_healing_per_min == 0) { _hero_healing_per_min = benchmarks.hero_healing_per_min.raw; return _hero_healing_per_min; } else { return _hero_healing_per_min; } } set { _hero_healing_per_min = value; } }
        //backing fields
        [NotMapped]
        private float _xp_per_min           {get;set;}
        [NotMapped]                        
        private float _last_hits_per_min    {get;set;}
        [NotMapped]                        
        private float _hero_damage_per_min  {get;set;}
        [NotMapped]                         
        private float _hero_healing_per_min { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo info in this.GetType().GetProperties())
            {
                if (info.Name.Equals(benchmarks))
                {
                    sb.AppendLine(this.benchmarks.ToString());
                }
                else
                {
                    if (info.GetValue(this, null) == null)
                    {
                        sb.AppendLine(info.Name + ": {null}");
                    }
                    else
                    {
                        sb.AppendLine(info.Name + ":" + info.GetValue(this, null).ToString());
                    }
                }
            }
            return sb.ToString();
        }
    }
}
