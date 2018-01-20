namespace OpenDotaInterface.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DraftTiming",
                c => new
                    {
                        DrafTimingId = c.Int(nullable: false, identity: true),
                        match_id = c.Long(nullable: false),
                        order = c.Int(nullable: false),
                        pick = c.Boolean(nullable: false),
                        active_team = c.Int(nullable: false),
                        hero_id = c.Int(nullable: false),
                        player_slot = c.String(),
                        extra_time = c.Int(nullable: false),
                        total_time_taken = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DrafTimingId)
                .ForeignKey("dbo.Match", t => t.match_id, cascadeDelete: true)
                .Index(t => t.match_id);
            
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        match_id = c.Long(nullable: false),
                        barracks_status_dire = c.Int(nullable: false),
                        barracks_status_radiant = c.Int(nullable: false),
                        dire_score = c.Int(nullable: false),
                        duration = c.Int(nullable: false),
                        first_blood_time = c.Int(nullable: false),
                        game_mode = c.Int(nullable: false),
                        lobby_type = c.Int(nullable: false),
                        radiant_score = c.Int(nullable: false),
                        radiant_win = c.Boolean(nullable: false),
                        start_time = c.Int(nullable: false),
                        number_teamfights = c.Int(nullable: false),
                        tower_status_radiant = c.Int(nullable: false),
                        tower_status_dire = c.Int(nullable: false),
                        patch = c.Int(nullable: false),
                        region = c.Int(nullable: false),
                        replay_url = c.String(),
                    })
                .PrimaryKey(t => t.match_id);
            
            CreateTable(
                "dbo.Objective",
                c => new
                    {
                        ObjectiveId = c.Int(nullable: false, identity: true),
                        match_id = c.Long(nullable: false),
                        time = c.Int(nullable: false),
                        type = c.String(),
                        unit = c.String(),
                        key = c.String(),
                        player_slot = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ObjectiveId)
                .ForeignKey("dbo.Match", t => t.match_id, cascadeDelete: true)
                .Index(t => t.match_id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        match_id = c.Long(nullable: false),
                        player_slot = c.Int(nullable: false),
                        account_id = c.String(),
                        assists = c.Int(nullable: false),
                        deaths = c.Int(nullable: false),
                        denies = c.Int(nullable: false),
                        gold = c.Int(nullable: false),
                        gold_per_min = c.Int(nullable: false),
                        gold_spent = c.Int(nullable: false),
                        hero_damage = c.Int(nullable: false),
                        hero_healing = c.Int(nullable: false),
                        hero_id = c.Int(nullable: false),
                        item_0 = c.Int(nullable: false),
                        item_1 = c.Int(nullable: false),
                        item_2 = c.Int(nullable: false),
                        item_3 = c.Int(nullable: false),
                        item_4 = c.Int(nullable: false),
                        item_5 = c.Int(nullable: false),
                        kills = c.Int(nullable: false),
                        last_hits = c.Int(nullable: false),
                        level = c.Int(nullable: false),
                        obs_placed = c.Int(nullable: false),
                        party_size = c.Int(nullable: false),
                        pred_vict = c.Boolean(nullable: false),
                        randomed = c.Boolean(nullable: false),
                        roshans_killed = c.Int(nullable: false),
                        rune_pickups = c.Int(nullable: false),
                        sen_placed = c.Int(nullable: false),
                        teamfight_participation = c.Single(nullable: false),
                        tower_damage = c.Int(nullable: false),
                        personaname = c.String(),
                        isRadiant = c.Boolean(nullable: false),
                        win = c.Int(nullable: false),
                        lose = c.Int(nullable: false),
                        total_gold = c.Int(nullable: false),
                        total_xp = c.Int(nullable: false),
                        kills_per_min = c.Single(nullable: false),
                        lane = c.Int(nullable: false),
                        lane_role = c.Int(nullable: false),
                        rank_tier = c.String(),
                        xp_per_min = c.Int(nullable: false),
                        last_hits_per_min = c.Int(nullable: false),
                        hero_damage_per_min = c.Int(nullable: false),
                        hero_healing_per_min = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Match", t => t.match_id, cascadeDelete: true)
                .Index(t => t.match_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "match_id", "dbo.Match");
            DropForeignKey("dbo.Objective", "match_id", "dbo.Match");
            DropForeignKey("dbo.DraftTiming", "match_id", "dbo.Match");
            DropIndex("dbo.Player", new[] { "match_id" });
            DropIndex("dbo.Objective", new[] { "match_id" });
            DropIndex("dbo.DraftTiming", new[] { "match_id" });
            DropTable("dbo.Player");
            DropTable("dbo.Objective");
            DropTable("dbo.Match");
            DropTable("dbo.DraftTiming");
        }
    }
}
