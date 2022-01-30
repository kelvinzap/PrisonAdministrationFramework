namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendedInmate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmates", "Complexion", c => c.String(nullable: false));
            AddColumn("dbo.Inmates", "BankVerificationNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Inmates", "IdentificationNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Inmates", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.Inmates", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.Inmates", "BirthCity", c => c.String(nullable: false));
            AddColumn("dbo.Inmates", "Nationality", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inmates", "Nationality");
            DropColumn("dbo.Inmates", "BirthCity");
            DropColumn("dbo.Inmates", "Weight");
            DropColumn("dbo.Inmates", "Height");
            DropColumn("dbo.Inmates", "IdentificationNumber");
            DropColumn("dbo.Inmates", "BankVerificationNumber");
            DropColumn("dbo.Inmates", "Complexion");
        }
    }
}
