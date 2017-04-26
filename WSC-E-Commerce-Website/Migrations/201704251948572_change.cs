namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseOrders", "PurchaseOrderStatuesID", "dbo.PurchaseOrderStatus");
            DropIndex("dbo.PurchaseOrders", new[] { "PurchaseOrderStatuesID" });
            DropColumn("dbo.PurchaseOrders", "PurchaseOrderStatuesID");
            DropTable("dbo.PurchaseOrderStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PurchaseOrderStatus",
                c => new
                    {
                        PurchaseOrderStatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseOrderStatusID);
            
            AddColumn("dbo.PurchaseOrders", "PurchaseOrderStatuesID", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseOrders", "PurchaseOrderStatuesID");
            AddForeignKey("dbo.PurchaseOrders", "PurchaseOrderStatuesID", "dbo.PurchaseOrderStatus", "PurchaseOrderStatusID", cascadeDelete: true);
        }
    }
}
