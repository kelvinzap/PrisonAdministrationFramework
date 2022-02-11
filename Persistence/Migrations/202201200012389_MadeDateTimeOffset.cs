using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
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
