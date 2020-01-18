namespace MemmbersMeals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCascadeDeleteFromMemmbers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Meals", "Memmber_ID1", "dbo.Memmbers");
            DropIndex("dbo.Meals", new[] { "Memmber_ID1" });
            DropColumn("dbo.Meals", "Memmber_ID");
            RenameColumn(table: "dbo.Meals", name: "Memmber_ID1", newName: "Memmber_ID");
            AddForeignKey("dbo.Meals", "Memmber_ID", "dbo.Memmbers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meals", "Memmber_ID", "dbo.Memmbers");
            RenameColumn(table: "dbo.Meals", name: "Memmber_ID", newName: "Memmber_ID1");
            AddColumn("dbo.Meals", "Memmber_ID", c => c.Int());
            CreateIndex("dbo.Meals", "Memmber_ID1");
            AddForeignKey("dbo.Meals", "Memmber_ID1", "dbo.Memmbers", "ID", cascadeDelete: true);
        }
    }
}
