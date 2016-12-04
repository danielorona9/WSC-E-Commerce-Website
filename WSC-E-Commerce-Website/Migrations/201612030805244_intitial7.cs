namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial7 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BillingInfo", new[] { "CreditCardTypeId" });
            CreateIndex("dbo.BillingInfo", "CreditCardTypeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BillingInfo", new[] { "CreditCardTypeID" });
            CreateIndex("dbo.BillingInfo", "CreditCardTypeId");
        }
    }
}
