namespace MemmbersMeals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteDuplicatedMealTableForignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Meals", name: "MemmberID", newName: "Memmber_ID1");
            RenameIndex(table: "dbo.Meals", name: "IX_MemmberID", newName: "IX_Memmber_ID1");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Meals", name: "IX_Memmber_ID1", newName: "IX_MemmberID");
            RenameColumn(table: "dbo.Meals", name: "Memmber_ID1", newName: "MemmberID");
        }
    }
}
