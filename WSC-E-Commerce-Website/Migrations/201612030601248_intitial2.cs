namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.User", "RegisteredDate");
            DropColumn("dbo.User", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "RegisteredDate", c => c.DateTime(nullable: false));
        }
    }
}
