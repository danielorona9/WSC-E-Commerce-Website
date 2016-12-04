namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BillingInfo", "CreditNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BillingInfo", "CreditNumber", c => c.Int(nullable: false));
        }
    }
}
