using System.Data.Entity.Migrations;

namespace PrisonAdministrationSystem.Migrations
{
    public partial class MadeDateOfReleaseNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inmates", "DateOfRelease", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inmates", "DateOfRelease", c => c.DateTime(nullable: false));
        }
    }
}
