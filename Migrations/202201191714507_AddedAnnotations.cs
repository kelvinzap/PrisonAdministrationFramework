namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inmates", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Inmates", "MiddleName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Inmates", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Inmates", "Gender", c => c.String(maxLength: 15));
            AlterColumn("dbo.Inmates", "Offense", c => c.String(nullable: false));
            AlterColumn("dbo.Inmates", "Sentence", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Inmates", "Remission", c => c.String(nullable: false));
            AlterColumn("dbo.Inmates", "FrontProfile", c => c.String(nullable: false));
            AlterColumn("dbo.Inmates", "SideProfile", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inmates", "SideProfile", c => c.String());
            AlterColumn("dbo.Inmates", "FrontProfile", c => c.String());
            AlterColumn("dbo.Inmates", "Remission", c => c.String());
            AlterColumn("dbo.Inmates", "Sentence", c => c.String());
            AlterColumn("dbo.Inmates", "Offense", c => c.String());
            AlterColumn("dbo.Inmates", "Gender", c => c.String());
            AlterColumn("dbo.Inmates", "LastName", c => c.String());
            AlterColumn("dbo.Inmates", "MiddleName", c => c.String());
            AlterColumn("dbo.Inmates", "FirstName", c => c.String());
        }
    }
}
