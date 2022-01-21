namespace PrisonAdministrationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "SurName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "MaidenName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "IdentificationNumber", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Nationality", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthCity", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "MaritalStatus", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Weight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Weight");
            DropColumn("dbo.AspNetUsers", "Height");
            DropColumn("dbo.AspNetUsers", "MaritalStatus");
            DropColumn("dbo.AspNetUsers", "BirthCity");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Nationality");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "IdentificationNumber");
            DropColumn("dbo.AspNetUsers", "MaidenName");
            DropColumn("dbo.AspNetUsers", "SurName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
        }
    }
}
