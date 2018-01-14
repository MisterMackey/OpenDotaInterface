using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DBO
{
    /// <summary>
    /// represents a single bechmark from the json
    /// </summary>
    public class BenchMark
    {

            public float raw { get; set; }
            public float pct { get; set; }
            public override string ToString()
            {
                return "raw: " + this.raw + "\npct: " + this.pct;
            }

    }
}
