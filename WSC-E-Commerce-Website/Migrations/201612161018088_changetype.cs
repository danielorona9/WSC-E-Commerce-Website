namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseOrders", "CartID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseOrders", "CartID", c => c.Int(nullable: false));
        }
    }
}
