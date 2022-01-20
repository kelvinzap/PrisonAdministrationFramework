namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInmateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OccupantNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inmates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                .ForeignKey("dbo.Cells", t => t.CellId, cascadeDelete: true)
                .Index(t => t.CellId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inmates", "CellId", "dbo.Cells");
            DropIndex("dbo.Inmates", new[] { "CellId" });
            DropTable("dbo.Inmates");
            DropTable("dbo.Cells");
        }
    }
}
