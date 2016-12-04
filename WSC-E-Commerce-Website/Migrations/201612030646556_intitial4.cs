namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BillingInfo", "ApplicationUserID", "dbo.User");
            DropIndex("dbo.BillingInfo", new[] { "ApplicationUserID" });
            AlterColumn("dbo.BillingInfo", "ApplicationUserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.BillingInfo", "ApplicationUserID");
            AddForeignKey("dbo.BillingInfo", "ApplicationUserID", "dbo.User", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillingInfo", "ApplicationUserID", "dbo.User");
            DropIndex("dbo.BillingInfo", new[] { "ApplicationUserID" });
            AlterColumn("dbo.BillingInfo", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.BillingInfo", "ApplicationUserID");
            AddForeignKey("dbo.BillingInfo", "ApplicationUserID", "dbo.User", "UserID");
        }
    }
}
