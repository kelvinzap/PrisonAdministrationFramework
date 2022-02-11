using System.Data.Entity.Migrations;

namespace PrisonAdministrationSystem.Migrations
{
    public partial class AddedEmailToStaff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "Email");
        }
    }
}
