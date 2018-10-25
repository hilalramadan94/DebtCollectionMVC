namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUsernametoCollectorIdtoHomeVisit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeVisits", "CollectorId", c => c.String());
            DropColumn("dbo.HomeVisits", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomeVisits", "Username", c => c.Int(nullable: false));
            DropColumn("dbo.HomeVisits", "CollectorId");
        }
    }
}
