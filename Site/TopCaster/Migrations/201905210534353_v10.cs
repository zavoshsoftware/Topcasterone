namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductGroupId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Products", "ProductGroupId");
            AddForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups");
            DropIndex("dbo.Products", new[] { "ProductGroupId" });
            DropColumn("dbo.Products", "ProductGroupId");
        }
    }
}
