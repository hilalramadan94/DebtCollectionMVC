namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditModelRoleMenu2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RoleMenus", "MenuId");
            AddForeignKey("dbo.RoleMenus", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMenus", "MenuId", "dbo.Menus");
            DropIndex("dbo.RoleMenus", new[] { "MenuId" });
        }
    }
}
