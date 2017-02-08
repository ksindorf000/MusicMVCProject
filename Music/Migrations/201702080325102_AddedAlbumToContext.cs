namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlbumToContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BandId = c.Int(nullable: false),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.BandId, cascadeDelete: true)
                .Index(t => t.BandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "BandId", "dbo.Bands");
            DropIndex("dbo.Albums", new[] { "BandId" });
            DropTable("dbo.Albums");
        }
    }
}
