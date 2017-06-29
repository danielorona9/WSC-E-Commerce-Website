namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseOrders", "RecordId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "RecordId", c => c.Int(nullable: false));
        }
    }
}
