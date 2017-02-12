namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAlbumToAlbumIdOnTracks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "Id", "dbo.Albums");
            DropIndex("dbo.Tracks", new[] { "Id" });
            DropPrimaryKey("dbo.Tracks");
            AddColumn("dbo.Tracks", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tracks", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tracks", "Id");
            CreateIndex("dbo.Tracks", "AlbumId");
            AddForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropPrimaryKey("dbo.Tracks");
            AlterColumn("dbo.Tracks", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Tracks", "AlbumId");
            AddPrimaryKey("dbo.Tracks", "Id");
            CreateIndex("dbo.Tracks", "Id");
            AddForeignKey("dbo.Tracks", "Id", "dbo.Albums", "Id");
        }
    }
}
