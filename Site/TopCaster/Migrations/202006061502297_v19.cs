namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v19 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 200),
                        Email = c.String(maxLength: 256),
                        Message = c.String(nullable: false),
                        Response = c.String(),
                        BlogId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            AddColumn("dbo.Blogs", "Summery", c => c.String());
            AddColumn("dbo.Blogs", "UrlParam", c => c.String());
            AddColumn("dbo.Blogs", "Visit", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "PageTitle", c => c.String());
            AddColumn("dbo.Blogs", "PageDescription", c => c.String());
            AlterColumn("dbo.Blogs", "Title", c => c.String());
            AlterColumn("dbo.Blogs", "ImageUrl", c => c.String());
            DropColumn("dbo.Blogs", "VisitNumber");
            DropColumn("dbo.Blogs", "Order");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Order", c => c.Int());
            AddColumn("dbo.Blogs", "VisitNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            AlterColumn("dbo.Blogs", "ImageUrl", c => c.String(maxLength: 200));
            AlterColumn("dbo.Blogs", "Title", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Blogs", "PageDescription");
            DropColumn("dbo.Blogs", "PageTitle");
            DropColumn("dbo.Blogs", "Visit");
            DropColumn("dbo.Blogs", "UrlParam");
            DropColumn("dbo.Blogs", "Summery");
            DropTable("dbo.BlogComments");
        }
    }
}
