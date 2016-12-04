namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BillingInfo", name: "ApplicationUser_Id", newName: "ApplicationUserID");
            RenameIndex(table: "dbo.BillingInfo", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BillingInfo", name: "IX_ApplicationUserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.BillingInfo", name: "ApplicationUserID", newName: "ApplicationUser_Id");
        }
    }
}
