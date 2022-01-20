namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimeString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inmates", "DateOfRelease", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inmates", "DateOfRelease", c => c.DateTimeOffset(precision: 7));
        }
    }
}
