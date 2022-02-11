using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class AddedRoleID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "Role_Id", "dbo.StaffRoles");
            DropIndex("dbo.Staffs", new[] { "Role_Id" });
            RenameColumn(table: "dbo.Staffs", name: "Role_Id", newName: "RoleId");
            AlterColumn("dbo.Staffs", "RoleId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Staffs", "RoleId");
            AddForeignKey("dbo.Staffs", "RoleId", "dbo.StaffRoles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "RoleId", "dbo.StaffRoles");
            DropIndex("dbo.Staffs", new[] { "RoleId" });
            AlterColumn("dbo.Staffs", "RoleId", c => c.Byte());
            RenameColumn(table: "dbo.Staffs", name: "RoleId", newName: "Role_Id");
            CreateIndex("dbo.Staffs", "Role_Id");
            AddForeignKey("dbo.Staffs", "Role_Id", "dbo.StaffRoles", "Id");
        }
    }
}
