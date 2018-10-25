namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserDepartmentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "Department_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Department_Id", newName: "DepartmentId");
            AlterColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            AlterColumn("dbo.AspNetUsers", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.AspNetUsers", "Department_Id");
            AddForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
