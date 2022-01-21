namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
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
