using System.Data.Entity.Migrations;

namespace PrisonAdministrationSystem.Migrations
{
    public partial class ChangedInmateIdToString : DbMigration
    {
        public override void Up()
        {
        
            Sql("DROP TABLE dbo.Inmates;");

         

        }

        public override void Down()
        {
            DropPrimaryKey("dbo.Inmates");
            AlterColumn("dbo.Inmates", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Inmates", "Id");
        }
    }
}
