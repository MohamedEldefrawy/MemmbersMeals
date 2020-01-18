namespace MemmbersMeals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeletedPropToMemmbersmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memmbers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memmbers", "IsDeleted");
        }
    }
}
