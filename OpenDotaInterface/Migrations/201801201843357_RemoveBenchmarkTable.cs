namespace OpenDotaInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveBenchmarkTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Player", "benchmarks_BenchMarksId", "dbo.Benchmarks");
            DropIndex("dbo.Player", new[] { "benchmarks_BenchMarksId" });
            AddColumn("dbo.Player", "xp_per_min", c => c.Single(nullable: false));
            AddColumn("dbo.Player", "last_hits_per_min", c => c.Single(nullable: false));
            AddColumn("dbo.Player", "hero_damage_per_min", c => c.Single(nullable: false));
            AddColumn("dbo.Player", "hero_healing_per_min", c => c.Single(nullable: false));
            DropColumn("dbo.Player", "benchmarks_BenchMarksId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Player", "benchmarks_BenchMarksId", c => c.Int());
            DropColumn("dbo.Player", "hero_healing_per_min");
            DropColumn("dbo.Player", "hero_damage_per_min");
            DropColumn("dbo.Player", "last_hits_per_min");
            DropColumn("dbo.Player", "xp_per_min");
            CreateIndex("dbo.Player", "benchmarks_BenchMarksId");
            AddForeignKey("dbo.Player", "benchmarks_BenchMarksId", "dbo.Benchmarks", "BenchMarksId");
        }
    }
}
