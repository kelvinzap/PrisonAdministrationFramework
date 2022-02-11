using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class AddedBankVerificationNumberToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BankVerificationNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Passport", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Passport", c => c.String());
            DropColumn("dbo.AspNetUsers", "BankVerificationNumber");
        }
    }
}
