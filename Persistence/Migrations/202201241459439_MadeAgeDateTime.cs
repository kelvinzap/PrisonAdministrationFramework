using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class MadeAgeDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inmates", "Age", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inmates", "Age", c => c.Byte(nullable: false));
        }
    }
}
