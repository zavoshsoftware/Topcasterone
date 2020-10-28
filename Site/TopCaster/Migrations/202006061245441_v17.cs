namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sliders", "Summary", c => c.String(maxLength: 600));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "Summary", c => c.String(maxLength: 200));
        }
    }
}
