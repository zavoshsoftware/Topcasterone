namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BranchDetails", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.BranchDetails", "BranchIconId", "dbo.BranchIcons");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PageGroups", "ParentId", "dbo.PageGroups");
            DropForeignKey("dbo.Pages", "PageGroupId", "dbo.PageGroups");
            DropIndex("dbo.BranchDetails", new[] { "BranchId" });
            DropIndex("dbo.BranchDetails", new[] { "BranchIconId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.PageGroups", new[] { "ParentId" });
            DropIndex("dbo.Pages", new[] { "PageGroupId" });
            DropTable("dbo.BranchIcons");
            DropTable("dbo.BranchDetails");
            DropTable("dbo.Branches");
            DropTable("dbo.Orders");
            DropTable("dbo.PageGroups");
            DropTable("dbo.Pages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Order = c.Int(nullable: false),
                        PageGroupId = c.Guid(nullable: false),
                        ImageUrl = c.String(),
                        Summery = c.String(),
                        Body = c.String(storeType: "ntext"),
                        Visit = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Order = c.Int(nullable: false),
                        ParentId = c.Guid(),
                        ImageUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                        CellNumber = c.String(),
                        ProductId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Order = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BranchDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                        BranchId = c.Guid(nullable: false),
                        BranchIconId = c.Guid(nullable: false),
                        Order = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BranchIcons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Icon = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionDate = c.DateTime(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Pages", "PageGroupId");
            CreateIndex("dbo.PageGroups", "ParentId");
            CreateIndex("dbo.Orders", "ProductId");
            CreateIndex("dbo.BranchDetails", "BranchIconId");
            CreateIndex("dbo.BranchDetails", "BranchId");
            AddForeignKey("dbo.Pages", "PageGroupId", "dbo.PageGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PageGroups", "ParentId", "dbo.PageGroups", "Id");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BranchDetails", "BranchIconId", "dbo.BranchIcons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BranchDetails", "BranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
