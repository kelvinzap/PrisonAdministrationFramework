using System.Data.Entity.Migrations;

namespace PrisonAdministrationSystem.Migrations
{
    public partial class MadeSurnameToMiddleName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MiddleName", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "SurName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "SurName", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "MiddleName");
        }
    }
}
