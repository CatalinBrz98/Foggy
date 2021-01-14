namespace Foggy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGamePoster : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "PosterPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "PosterPath", c => c.String());
        }
    }
}
