namespace OnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 300, unicode: false),
                        TrackingNo = c.String(maxLength: 10, unicode: false),
                        Staff = c.String(maxLength: 20, unicode: false),
                        Recipient = c.String(maxLength: 20, unicode: false),
                        CargoDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailId);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackingId = c.Int(nullable: false, identity: true),
                        Decription = c.String(maxLength: 100, unicode: false),
                        TrackingNo = c.String(maxLength: 10, unicode: false),
                        TrackingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
