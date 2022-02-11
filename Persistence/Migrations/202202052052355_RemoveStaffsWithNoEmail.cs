using System.Data.Entity.Migrations;

namespace PrisonAdministrationSystem.Migrations
{
    public partial class RemoveStaffsWithNoEmail : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Staffs WHERE Email is null");
        }
        
        public override void Down()
        {
        }
    }
}
