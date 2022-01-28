namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateOfCreationToInmate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inmates", "DateOfCreation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inmates", "DateOfCreation");
        }
    }
}
