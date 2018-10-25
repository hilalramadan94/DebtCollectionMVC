namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUsernametoCollectorIdtoHomeVisit1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HomeVisits", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.HomeVisits", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            DropColumn("dbo.HomeVisits", "CollectorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomeVisits", "CollectorId", c => c.String());
            RenameIndex(table: "dbo.HomeVisits", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.HomeVisits", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
