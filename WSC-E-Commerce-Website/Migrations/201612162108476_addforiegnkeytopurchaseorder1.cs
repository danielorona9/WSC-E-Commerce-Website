namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforiegnkeytopurchaseorder1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "ProductCatalogId" });
            CreateIndex("dbo.PurchaseOrders", "ProductCatalogID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "ProductCatalogID" });
            CreateIndex("dbo.PurchaseOrders", "ProductCatalogId");
        }
    }
}
