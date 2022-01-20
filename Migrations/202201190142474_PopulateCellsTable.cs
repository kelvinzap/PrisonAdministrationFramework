namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCellsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cells (OccupantNumber) VALUES(1)");
            Sql("INSERT INTO Cells (OccupantNumber) VALUES(3)");

        }

        public override void Down()
        {
            Sql("DELETE FROM Cells WHERE Id IN (1,2)");

        }
    }
}
