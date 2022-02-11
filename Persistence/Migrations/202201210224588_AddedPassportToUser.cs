using System.Data.Entity.Migrations;

namespace PrisonAdministrationSystem.Migrations
{
    public partial class AddedPassportToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Passport", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Passport");
        }
    }
}
