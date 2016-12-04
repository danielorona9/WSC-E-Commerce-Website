namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingInfo", "CreditCardNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BillingInfo", "CreditCardNumber");
        }
    }
}
