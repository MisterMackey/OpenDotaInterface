using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// represents a drafttiming from the match json
    /// </summary>
    public class DraftTiming
    {

        public int order { get; set; }
        public bool pick { get; set; }
        public int active_team { get; set; }
        public int hero_id { get; set; }
        public string player_slot { get; set; }
        public int extra_time { get; set; }
        public int total_time_taken { get; set; }
        
    }
}
