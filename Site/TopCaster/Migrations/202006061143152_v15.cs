namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductGroups", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.ProductGroups", "UrlParam", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.ProductGroups", "PageTitle", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.ProductGroups", "PageDescription", c => c.String(maxLength: 1000));
            AddColumn("dbo.ProductGroups", "ImageUrl", c => c.String(maxLength: 500));
            AddColumn("dbo.ProductGroups", "Summery", c => c.String());
            AddColumn("dbo.ProductGroups", "Body", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.ProductGroups", "Title", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductGroups", "Title", c => c.String());
            DropColumn("dbo.ProductGroups", "Body");
            DropColumn("dbo.ProductGroups", "Summery");
            DropColumn("dbo.ProductGroups", "ImageUrl");
            DropColumn("dbo.ProductGroups", "PageDescription");
            DropColumn("dbo.ProductGroups", "PageTitle");
            DropColumn("dbo.ProductGroups", "UrlParam");
            DropColumn("dbo.ProductGroups", "Order");
        }
    }
}
