﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// describes a single player in the players json
    /// </summary>
    public class Player
    {
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
        public Benchmarks benchmarks { get; set; }

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
