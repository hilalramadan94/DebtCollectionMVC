namespace DebtCollectionMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeHomeVisitGeoLatLngDecimalFormat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HomeVisits", "GeoLat", c => c.Decimal(precision: 12, scale: 10));
            AlterColumn("dbo.HomeVisits", "GeoLng", c => c.Decimal(precision: 12, scale: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HomeVisits", "GeoLng", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.HomeVisits", "GeoLat", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
