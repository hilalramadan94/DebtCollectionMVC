namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActivetoUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean());
            AddColumn("dbo.RoleMenus", "RoleId", c => c.String(nullable: false));
            AddColumn("dbo.RoleMenus", "IdentityRole_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.RoleMenus", "IdentityRole_Id");
            AddForeignKey("dbo.RoleMenus", "IdentityRole_Id", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMenus", "IdentityRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.RoleMenus", new[] { "IdentityRole_Id" });
            DropColumn("dbo.RoleMenus", "IdentityRole_Id");
            DropColumn("dbo.RoleMenus", "RoleId");
            DropColumn("dbo.AspNetUsers", "IsActive");
        }
    }
}
