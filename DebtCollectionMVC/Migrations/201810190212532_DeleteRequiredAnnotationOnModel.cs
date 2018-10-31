namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRequiredAnnotationOnModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Companies", newName: "Departments");
            DropForeignKey("dbo.Debts", "DepartmentId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Companies");
            DropIndex("dbo.Debts", new[] { "DepartmentId" });
            DropIndex("dbo.AspNetUsers", new[] { "DepartmentId" });
            AddColumn("dbo.Debts", "Department_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Department_Id", c => c.Int());
            CreateIndex("dbo.Debts", "Department_Id");
            CreateIndex("dbo.AspNetUsers", "Department_Id");
            AddForeignKey("dbo.Debts", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Debts", "Department_Id", "dbo.Departments");
            DropIndex("dbo.AspNetUsers", new[] { "Department_Id" });
            DropIndex("dbo.Debts", new[] { "Department_Id" });
            DropColumn("dbo.AspNetUsers", "Department_Id");
            DropColumn("dbo.Debts", "Department_Id");
            CreateIndex("dbo.AspNetUsers", "DepartmentId");
            CreateIndex("dbo.Debts", "DepartmentId");
            AddForeignKey("dbo.AspNetUsers", "DepartmentId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Debts", "DepartmentId", "dbo.Companies", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Departments", newName: "Companies");
        }
    }
}
