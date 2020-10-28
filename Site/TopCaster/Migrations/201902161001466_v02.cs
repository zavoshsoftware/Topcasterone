namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "ImageUrl");
        }
    }
}
