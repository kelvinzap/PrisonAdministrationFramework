namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimeOffset : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inmates", "DateOfRelease", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inmates", "DateOfRelease", c => c.DateTime());
        }
    }
}
