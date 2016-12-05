namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateOrderStatus : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Pending')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Cancelled')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Validated')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'In Progress')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Shipped')");
        }
        
        public override void Down()
        {
        }
    }
}
