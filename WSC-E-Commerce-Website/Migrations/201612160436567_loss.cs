namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Billing", "PurchaseOrdersID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.OrderRequest", "PurchaseOrdersID", "dbo.PurchaseOrders");
            DropIndex("dbo.Billing", new[] { "PurchaseOrdersID" });
            DropIndex("dbo.OrderRequest", new[] { "PurchaseOrdersID" });
            DropPrimaryKey("dbo.PurchaseOrders");
            AlterColumn("dbo.PurchaseOrders", "PurchaseOrdersID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Billing", "PurchaseOrdersID", c => c.String(maxLength: 128));
            AlterColumn("dbo.OrderRequest", "PurchaseOrdersID", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.PurchaseOrders", "PurchaseOrdersID");
            CreateIndex("dbo.Billing", "PurchaseOrdersID");
            CreateIndex("dbo.OrderRequest", "PurchaseOrdersID");
            AddForeignKey("dbo.Billing", "PurchaseOrdersID", "dbo.PurchaseOrders", "PurchaseOrdersID");
            AddForeignKey("dbo.OrderRequest", "PurchaseOrdersID", "dbo.PurchaseOrders", "PurchaseOrdersID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRequest", "PurchaseOrdersID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.Billing", "PurchaseOrdersID", "dbo.PurchaseOrders");
            DropIndex("dbo.OrderRequest", new[] { "PurchaseOrdersID" });
            DropIndex("dbo.Billing", new[] { "PurchaseOrdersID" });
            DropPrimaryKey("dbo.PurchaseOrders");
            AlterColumn("dbo.OrderRequest", "PurchaseOrdersID", c => c.Int(nullable: false));
            AlterColumn("dbo.Billing", "PurchaseOrdersID", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseOrders", "PurchaseOrdersID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PurchaseOrders", "PurchaseOrdersID");
            CreateIndex("dbo.OrderRequest", "PurchaseOrdersID");
            CreateIndex("dbo.Billing", "PurchaseOrdersID");
            AddForeignKey("dbo.OrderRequest", "PurchaseOrdersID", "dbo.PurchaseOrders", "PurchaseOrdersID", cascadeDelete: true);
            AddForeignKey("dbo.Billing", "PurchaseOrdersID", "dbo.PurchaseOrders", "PurchaseOrdersID", cascadeDelete: true);
        }
    }
}
