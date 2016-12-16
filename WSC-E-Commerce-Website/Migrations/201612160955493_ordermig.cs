namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordermig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderRequest", "Orders_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderRequest", new[] { "Orders_OrderId" });
            RenameColumn(table: "dbo.OrderRequest", name: "Orders_OrderId", newName: "OrderId");
            AlterColumn("dbo.OrderRequest", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderRequest", "OrderId");
            AddForeignKey("dbo.OrderRequest", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRequest", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderRequest", new[] { "OrderId" });
            AlterColumn("dbo.OrderRequest", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.OrderRequest", name: "OrderId", newName: "Orders_OrderId");
            CreateIndex("dbo.OrderRequest", "Orders_OrderId");
            AddForeignKey("dbo.OrderRequest", "Orders_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
