using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
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
