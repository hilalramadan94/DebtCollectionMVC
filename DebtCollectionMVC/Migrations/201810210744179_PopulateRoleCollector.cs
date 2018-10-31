namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRoleCollector : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'99', N'Collector')");
        }
        
        public override void Down()
        {
        }
    }
}
