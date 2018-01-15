using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// represents an objective from the match json
    /// </summary>
    public class Objective
    {
        [Key]
        public int ObjectiveId {get;set;}
        //foreign key
        public Int64 match_id { get; set; }
        public int time { get; set; }
        public string type { get; set; }
        public string unit { get; set; }
        public string key { get; set; }
        public int player_slot { get; set; }
    }
}
