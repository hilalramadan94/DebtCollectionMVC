namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDepartmentIdtoDebt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Debts", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Debts", new[] { "Department_Id" });
            RenameColumn(table: "dbo.Debts", name: "Department_Id", newName: "DepartmentId");
            AlterColumn("dbo.Debts", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Debts", "DepartmentId");
            AddForeignKey("dbo.Debts", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            DropColumn("dbo.Debts", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Debts", "CompanyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Debts", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Debts", new[] { "DepartmentId" });
            AlterColumn("dbo.Debts", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Debts", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.Debts", "Department_Id");
            AddForeignKey("dbo.Debts", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
