namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.User", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            AddColumn("dbo.OrderRequest", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.OrderRequest", "Order_OrderId");
            AddForeignKey("dbo.OrderRequest", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRequest", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ApplicationUserId", "dbo.User");
            DropIndex("dbo.OrderRequest", new[] { "Order_OrderId" });
            DropIndex("dbo.Orders", new[] { "ApplicationUserId" });
            DropColumn("dbo.OrderRequest", "Order_OrderId");
            DropTable("dbo.Orders");
        }
    }
}
