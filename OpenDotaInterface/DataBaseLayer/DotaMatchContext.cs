using System;
using System.Collections.Generic;
using System.Data.Entity;
using OpenDotaInterface.DBO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //to allow singleton names for tables.
        }

        public DotaMatchContext() : base("Data Source = NLLR4000295597; Integrated Security = True") // read https://odetocode.com/Blogs/scott/archive/2012/08/14/a-troubleshooting-guide-for-entity-framework-connections-amp-migrations.aspx
        {
            Console.Write(Database.Connection.ConnectionString);
        }
    }

    
}
