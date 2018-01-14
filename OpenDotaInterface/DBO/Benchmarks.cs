using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// represents a benchmarks of the benchmarks json (inside players json)
    /// </summary>
    public class Benchmarks
    {
        public Benchmark gold_per_min { get; set; }
        public Benchmark xp_per_min { get; set; }
        public Benchmark kills_per_min { get; set; }
        public Benchmark last_hit_per_min { get; set; }
        public Benchmark hero_damage_per_min { get; set; }
        public Benchmark hero_healing_per_min { get; set; }
        public Benchmark tower_damage { get; set; }

        public struct Benchmark
        {
            public float raw { get; set; }
            public float pct { get; set; }
            public override string ToString()
            {
                return "raw: " + this.raw + "\npct: " + this.pct;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(gold_per_min.ToString());
            sb.AppendLine(xp_per_min.ToString());
            sb.AppendLine(kills_per_min.ToString());
            sb.AppendLine(last_hit_per_min.ToString());
            sb.AppendLine(hero_damage_per_min.ToString());
            sb.AppendLine(hero_healing_per_min.ToString());
            sb.AppendLine(tower_damage.ToString());
            return sb.ToString();
        }

        /* example json
          "gold_per_min": {
       "raw": 775,
       "pct": 0.98986486486486491
     },
     "xp_per_min": {
       "raw": 734,
       "pct": 0.86148648648648651
     },
     "kills_per_min": {
       "raw": 0.3047091412742382,
       "pct": 0.84628378378378377
     },
     "last_hits_per_min": {
       "raw": 8.310249307479225,
       "pct": 0.95945945945945943
     },
     "hero_damage_per_min": {
       "raw": 877.89473684210532,
       "pct": 0.910472972972973
     },
     "hero_healing_per_min": {
       "raw": 100.55401662049862,
       "pct": 0.79560810810810811
     },
     "tower_damage": {
       "raw": 9916,
       "pct": 0.98986486486486491
       */
    }
}
