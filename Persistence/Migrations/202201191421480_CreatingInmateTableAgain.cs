using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class CreatingInmateTableAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Inmates",
                    c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Age = c.Byte(nullable: false),
                        Gender = c.String(),
                        CellId = c.Int(nullable: false),
                        Offense = c.String(),
                        Sentence = c.String(),
                        Remission = c.String(),
                        DateOfIncarceration = c.DateTime(nullable: false),
                        DateOfRelease = c.DateTime(nullable: false),
                        FrontProfile = c.String(),
                        SideProfile = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cells", t => t.CellId, cascadeDelete: true);
            DropPrimaryKey("dbo.Inmates");
            AlterColumn("dbo.Inmates", "Id", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Inmates", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Inmates");
            AlterColumn("dbo.Inmates", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Inmates", "Id");
        }
    }
}
