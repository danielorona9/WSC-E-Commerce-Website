namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingRoleTableAccessModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Description", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Description");
        }
    }
}
