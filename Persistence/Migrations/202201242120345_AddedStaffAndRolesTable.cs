using System.Data.Entity.Migrations;

namespace PrisonAdministrationFramework.Migrations
{
    public partial class AddedStaffAndRolesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaffRoles",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        MaidenName = c.String(nullable: false),
                        IdentificationNumber = c.Long(nullable: false),
                        Gender = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        BirthCity = c.String(nullable: false),
                        MaritalStatus = c.String(nullable: false),
                        Height = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Passport = c.String(nullable: false),
                        BankVerificationNumber = c.Long(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                        Role_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaffRoles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "Role_Id", "dbo.StaffRoles");
            DropIndex("dbo.Staffs", new[] { "Role_Id" });
            DropTable("dbo.Staffs");
            DropTable("dbo.StaffRoles");
        }
    }
}
