using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class AddedDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmates", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Inmates", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inmates", "Age", c => c.DateTime(nullable: false));
            DropColumn("dbo.Inmates", "DateOfBirth");
        }
    }
}
