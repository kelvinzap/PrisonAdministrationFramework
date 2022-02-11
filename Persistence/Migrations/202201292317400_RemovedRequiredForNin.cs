using System.Data.Entity.Migrations;

namespace PrisonAdministrationSystem.Migrations
{
    public partial class RemovedRequiredForNin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inmates", "BankVerificationNumber", c => c.Long());
            AlterColumn("dbo.Inmates", "IdentificationNumber", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inmates", "IdentificationNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.Inmates", "BankVerificationNumber", c => c.Long(nullable: false));
        }
    }
}
