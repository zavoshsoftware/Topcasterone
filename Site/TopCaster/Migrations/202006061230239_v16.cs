namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 256),
                        Message = c.String(nullable: false),
                        Response = c.String(),
                        ProductId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "Order", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "PageTitle", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "PageDescription", c => c.String(maxLength: 1000));
            AddColumn("dbo.Products", "ImageUrl", c => c.String(maxLength: 500));
            AddColumn("dbo.Products", "Summery", c => c.String());
            AddColumn("dbo.Products", "Body", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Products", "IsInHome", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsUpseller", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Package");
            DropColumn("dbo.Products", "Delivery");
            DropColumn("dbo.Products", "Payment");
            DropColumn("dbo.Products", "Validity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Validity", c => c.String());
            AddColumn("dbo.Products", "Payment", c => c.String());
            AddColumn("dbo.Products", "Delivery", c => c.String());
            AddColumn("dbo.Products", "Package", c => c.String());
            AddColumn("dbo.Products", "Quantity", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.String());
            DropForeignKey("dbo.ProductComments", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductComments", new[] { "ProductId" });
            AlterColumn("dbo.Products", "Title", c => c.String());
            DropColumn("dbo.Products", "IsUpseller");
            DropColumn("dbo.Products", "IsInHome");
            DropColumn("dbo.Products", "Body");
            DropColumn("dbo.Products", "Summery");
            DropColumn("dbo.Products", "ImageUrl");
            DropColumn("dbo.Products", "PageDescription");
            DropColumn("dbo.Products", "PageTitle");
            DropColumn("dbo.Products", "Code");
            DropColumn("dbo.Products", "Order");
            DropTable("dbo.ProductComments");
        }
    }
}
