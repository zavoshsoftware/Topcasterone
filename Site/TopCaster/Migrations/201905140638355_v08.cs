namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v08 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Title", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.String());
            AddColumn("dbo.Products", "Quantity", c => c.String());
            AddColumn("dbo.Products", "Package", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Package");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Title");
        }
    }
}
