namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingRoleTableAccessModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Description", c => c.String(nullable: false, maxLength: 128));

            // Alter database for "Discriminator" column
            AddColumn("dbo.Roles", "Discriminator", c => c.String(nullable: true, maxLength: (40)));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "Description");
        }
    }
}
