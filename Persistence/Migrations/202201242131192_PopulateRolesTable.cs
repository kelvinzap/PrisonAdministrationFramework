using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class PopulateRolesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO StaffRoles (Id, Name) VALUES(1, 'Correctional Officer')");
            Sql("INSERT INTO StaffRoles (Id, Name) VALUES(2, 'Doctor')");
            Sql("INSERT INTO StaffRoles (Id, Name) VALUES(3, 'Nurse')");
            Sql("INSERT INTO StaffRoles (Id, Name) VALUES(4, 'Psychologists')");
            Sql("INSERT INTO StaffRoles (Id, Name) VALUES(5, 'Chaplain')");
            Sql("INSERT INTO StaffRoles (Id, Name) VALUES(6, 'Caterer')");
            Sql("INSERT INTO StaffRoles (Id, Name) VALUES(7, 'Janitor')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Cells WHERE Id IN (1,7)");

        }
    }
}
