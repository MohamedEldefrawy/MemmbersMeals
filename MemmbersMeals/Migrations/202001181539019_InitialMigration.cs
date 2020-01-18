namespace MemmbersMeals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MealType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 9, scale: 2),
                        MealsDate = c.DateTime(storeType: "date"),
                        Memmber_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Memmbers", t => t.Memmber_ID)
                .Index(t => t.Memmber_ID);
            
            CreateTable(
                "dbo.Memmbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Credit = c.Decimal(precision: 9, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meals", "Memmber_ID", "dbo.Memmbers");
            DropIndex("dbo.Meals", new[] { "Memmber_ID" });
            DropTable("dbo.Memmbers");
            DropTable("dbo.Meals");
        }
    }
}
