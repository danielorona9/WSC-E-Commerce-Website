namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnCountToPurchaseOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders","Count", c=>c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "Count");
        }
    }
}
