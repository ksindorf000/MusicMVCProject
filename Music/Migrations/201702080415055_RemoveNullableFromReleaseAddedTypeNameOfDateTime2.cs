namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNullableFromReleaseAddedTypeNameOfDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "ReleaseDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "ReleaseDate", c => c.DateTime());
        }
    }
}
