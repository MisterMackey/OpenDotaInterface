using System;
using System.Collections.Generic;
using System.Data.Entity;
using OpenDotaInterface.DBO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaInterface.DataBaseLayer
{
    public class DotaMatchContext : DbContext
    {
        public DbSet<Match> matches { get; set; }
        public DbSet<DraftTiming> drafts { get; set; }
        public DbSet<Objective> objectives { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Benchmarks> benchmarks { get; set; }
        public DbSet<BenchMark> benchmark  { get; set; }
    }
}
