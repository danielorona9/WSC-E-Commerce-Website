namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingIdentityTablesAccess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLogin", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserRole", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserLogin", "ApplicationUser_Id");
            CreateIndex("dbo.UserRole", "ApplicationUser_Id");
            AddForeignKey("dbo.UserLogin", "ApplicationUser_Id", "dbo.User", "UserID");
            AddForeignKey("dbo.UserRole", "ApplicationUser_Id", "dbo.User", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "ApplicationUser_Id", "dbo.User");
            DropForeignKey("dbo.UserLogin", "ApplicationUser_Id", "dbo.User");
            DropIndex("dbo.UserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserLogin", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.UserRole", "ApplicationUser_Id");
            DropColumn("dbo.UserLogin", "ApplicationUser_Id");
        }
    }
}
