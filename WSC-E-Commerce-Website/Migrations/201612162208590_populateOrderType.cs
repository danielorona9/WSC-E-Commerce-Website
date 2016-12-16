using System.Data.Entity.Core.Metadata.Edm;

namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateOrderType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[OrderType] ([OrderTypeName]) VALUES(N'Pay Now')");
            Sql("INSERT INTO[dbo].[OrderType] ([OrderTypeName]) VALUES(N'Pay On Deliver')");



        }
        
        public override void Down()
        {
        }
    }
}
