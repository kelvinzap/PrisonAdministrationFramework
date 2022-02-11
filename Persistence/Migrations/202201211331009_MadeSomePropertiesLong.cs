using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class MadeSomePropertiesLong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateOfCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "IdentificationNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.AspNetUsers", "BankVerificationNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "BankVerificationNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "IdentificationNumber", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "DateOfCreation");
        }
    }
}
