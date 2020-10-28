namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v03 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Body", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Body", c => c.String());
        }
    }
}
