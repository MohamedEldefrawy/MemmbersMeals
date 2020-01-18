namespace MemmbersMeals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameForiegnKeyMemmberID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meals", "Memmber_ID", "dbo.Memmbers");
            DropIndex("dbo.Meals", new[] { "Memmber_ID" });
            RenameColumn(table: "dbo.Meals", name: "Memmber_ID", newName: "MemmberID");
            AlterColumn("dbo.Meals", "MemmberID", c => c.Int(nullable: false));
            CreateIndex("dbo.Meals", "MemmberID");
            AddForeignKey("dbo.Meals", "MemmberID", "dbo.Memmbers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meals", "MemmberID", "dbo.Memmbers");
            DropIndex("dbo.Meals", new[] { "MemmberID" });
            AlterColumn("dbo.Meals", "MemmberID", c => c.Int());
            RenameColumn(table: "dbo.Meals", name: "MemmberID", newName: "Memmber_ID");
            CreateIndex("dbo.Meals", "Memmber_ID");
            AddForeignKey("dbo.Meals", "Memmber_ID", "dbo.Memmbers", "ID");
        }
    }
}
