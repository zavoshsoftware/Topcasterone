namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v07 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Title");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Package");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Package", c => c.String());
            AddColumn("dbo.Products", "Quantity", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.String());
            AddColumn("dbo.Products", "Title", c => c.String());
        }
    }
}
