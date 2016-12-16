namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnSkewNumToProductCatalog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCatalog", "SkewNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCatalog", "SkewNumber");
        }
    }
}
