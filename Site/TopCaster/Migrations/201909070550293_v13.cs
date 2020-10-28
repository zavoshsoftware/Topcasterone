namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.BranchIcons", t => t.BranchIconId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.BranchIconId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BranchDetails", "BranchIconId", "dbo.BranchIcons");
            DropForeignKey("dbo.BranchDetails", "BranchId", "dbo.Branches");
            DropIndex("dbo.BranchDetails", new[] { "BranchIconId" });
            DropIndex("dbo.BranchDetails", new[] { "BranchId" });
            DropTable("dbo.Branches");
            DropTable("dbo.BranchDetails");
            DropTable("dbo.BranchIcons");
        }
    }
}
