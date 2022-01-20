namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeRemissionNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inmates", "Remission", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inmates", "Remission", c => c.String(nullable: false));
        }
    }
}
