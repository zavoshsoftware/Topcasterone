namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Body", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Products", "ImageUrl", c => c.String(maxLength: 200));
            AlterColumn("dbo.Blogs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Description", c => c.String(storeType: "ntext"));
            DropColumn("dbo.Products", "ImageUrl");
            DropColumn("dbo.Blogs", "Body");
        }
    }
}
