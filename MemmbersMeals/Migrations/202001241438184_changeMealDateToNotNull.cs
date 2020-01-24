namespace MemmbersMeals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMealDateToNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meals", "MealsDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meals", "MealsDate", c => c.DateTime(storeType: "date"));
        }
    }
}
