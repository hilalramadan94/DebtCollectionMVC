namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditModelRoleMenu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleMenus", "MenuId", "dbo.Menus");
            DropIndex("dbo.RoleMenus", new[] { "MenuId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.RoleMenus", "MenuId");
            AddForeignKey("dbo.RoleMenus", "MenuId", "dbo.Menus", "Id", cascadeDelete: true);
        }
    }
}
