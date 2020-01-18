namespace MemmbersMeals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsDeletedAttributeToMemmbers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memmbers", "isDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memmbers", "isDeleted");
        }
    }
}
