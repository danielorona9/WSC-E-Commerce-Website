namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "CartID", c => c.String(nullable: false));
            DropColumn("dbo.OrderRequest", "CartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderRequest", "CartId", c => c.String());
            DropColumn("dbo.PurchaseOrders", "CartID");
        }
    }
}
