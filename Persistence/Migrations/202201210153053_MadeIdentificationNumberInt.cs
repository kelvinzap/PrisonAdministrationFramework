using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class MadeIdentificationNumberInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "IdentificationNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "IdentificationNumber", c => c.String(nullable: false));
        }
    }
}
