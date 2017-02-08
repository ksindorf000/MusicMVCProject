namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTracks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(),
                        Length = c.Time(precision: 7),
                        Band_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Id)
                .ForeignKey("dbo.Bands", t => t.Band_Id)
                .Index(t => t.Id)
                .Index(t => t.Band_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.Tracks", "Id", "dbo.Albums");
            DropIndex("dbo.Tracks", new[] { "Band_Id" });
            DropIndex("dbo.Tracks", new[] { "Id" });
            DropTable("dbo.Tracks");
        }
    }
}
