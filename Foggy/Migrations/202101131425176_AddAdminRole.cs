namespace Foggy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES ('Admin', 'Admin')");
        }
        
        public override void Down()
        {
        }
    }
}
