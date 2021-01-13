namespace Foggy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Alpha2 = c.String(nullable: false, maxLength: 2),
                        Alpha3 = c.String(maxLength: 3),
                        UnCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Percentage = c.Single(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Price = c.Single(nullable: false),
                        PosterPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Positive = c.Boolean(nullable: false),
                        Text = c.String(nullable: false, maxLength: 500),
                        Game_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Game_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.DiscountCountries",
                c => new
                    {
                        Discount_Id = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Discount_Id, t.Country_Id })
                .ForeignKey("dbo.Discounts", t => t.Discount_Id, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.Discount_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.GameCategoryGames",
                c => new
                    {
                        GameCategory_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameCategory_Id, t.Game_Id })
                .ForeignKey("dbo.GameCategories", t => t.GameCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.GameCategory_Id)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Discounts", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.GameCategoryGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.GameCategoryGames", "GameCategory_Id", "dbo.GameCategories");
            DropForeignKey("dbo.DiscountCountries", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.DiscountCountries", "Discount_Id", "dbo.Discounts");
            DropIndex("dbo.GameCategoryGames", new[] { "Game_Id" });
            DropIndex("dbo.GameCategoryGames", new[] { "GameCategory_Id" });
            DropIndex("dbo.DiscountCountries", new[] { "Country_Id" });
            DropIndex("dbo.DiscountCountries", new[] { "Discount_Id" });
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropIndex("dbo.Reviews", new[] { "Game_Id" });
            DropIndex("dbo.Discounts", new[] { "Game_Id" });
            DropTable("dbo.GameCategoryGames");
            DropTable("dbo.DiscountCountries");
            DropTable("dbo.Reviews");
            DropTable("dbo.GameCategories");
            DropTable("dbo.Games");
            DropTable("dbo.Discounts");
            DropTable("dbo.Countries");
        }
    }
}
