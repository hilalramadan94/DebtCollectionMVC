namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MargingEmployeeWithApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Companies");
            DropForeignKey("dbo.HomeVisits", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.HomeVisits", new[] { "EmployeeId" });
            AddColumn("dbo.HomeVisits", "Username", c => c.Int(nullable: false));
            AddColumn("dbo.HomeVisits", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 255));
            CreateIndex("dbo.HomeVisits", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HomeVisits", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.HomeVisits", "EmployeeId");
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 255),
                        Telephone = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.HomeVisits", "EmployeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.HomeVisits", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            DropIndex("dbo.HomeVisits", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "DepartmentId");
            DropColumn("dbo.HomeVisits", "ApplicationUser_Id");
            DropColumn("dbo.HomeVisits", "Username");
            CreateIndex("dbo.HomeVisits", "EmployeeId");
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.HomeVisits", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
