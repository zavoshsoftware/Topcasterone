namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v061 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Quantity", c => c.String());
            AlterColumn("dbo.Products", "Package", c => c.String());
            AlterColumn("dbo.Products", "Delivery", c => c.String());
            AlterColumn("dbo.Products", "Payment", c => c.String());
            AlterColumn("dbo.Products", "Validity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Validity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Delivery", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Package", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
