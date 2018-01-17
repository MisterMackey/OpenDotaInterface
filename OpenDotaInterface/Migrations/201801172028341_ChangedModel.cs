namespace OpenDotaInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Benchmarks", name: "last_hit_per_min_BenchMarkId", newName: "last_hits_per_min_BenchMarkId");
            RenameIndex(table: "dbo.Benchmarks", name: "IX_last_hit_per_min_BenchMarkId", newName: "IX_last_hits_per_min_BenchMarkId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Benchmarks", name: "IX_last_hits_per_min_BenchMarkId", newName: "IX_last_hit_per_min_BenchMarkId");
            RenameColumn(table: "dbo.Benchmarks", name: "last_hits_per_min_BenchMarkId", newName: "last_hit_per_min_BenchMarkId");
        }
    }
}
