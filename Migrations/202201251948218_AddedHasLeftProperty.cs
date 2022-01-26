namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHasLeftProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmates", "HasLeft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Staffs", "HasLeft", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "HasLeft");
            DropColumn("dbo.Inmates", "HasLeft");
        }
    }
}
