namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderRequest", name: "Order_OrderId", newName: "Orders_OrderId");
            RenameIndex(table: "dbo.OrderRequest", name: "IX_Order_OrderId", newName: "IX_Orders_OrderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderRequest", name: "IX_Orders_OrderId", newName: "IX_Order_OrderId");
            RenameColumn(table: "dbo.OrderRequest", name: "Orders_OrderId", newName: "Order_OrderId");
        }
    }
}
