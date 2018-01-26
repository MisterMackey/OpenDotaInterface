using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACommonLibrary.ModelObjects
{
    /// <summary>
    /// represents a single bechmark from the json
    /// </summary>
    public class BenchMark
    {
        [Key]
        public int BenchMarkId { get; set; }
        //foreign key 
        public int BenchMarksId { get; set; }
        public float raw { get; set; }
        public float pct { get; set; }
        public override string ToString()
        {
            return "raw: " + this.raw + "\npct: " + this.pct;
        }

    }
}
