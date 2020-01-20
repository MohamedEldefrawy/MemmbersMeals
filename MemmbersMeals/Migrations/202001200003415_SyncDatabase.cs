namespace MemmbersMeals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Memmbers", "Credit", c => c.Decimal(nullable: false, precision: 9, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Memmbers", "Credit", c => c.Decimal(precision: 9, scale: 2));
        }
    }
}
