namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v062 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Percent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Percent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
