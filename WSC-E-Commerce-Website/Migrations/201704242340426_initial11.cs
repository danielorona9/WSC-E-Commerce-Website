using System.Data.Entity.Migrations.Builders;
using System.Data.Entity.Migrations.Model;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("ProductCatalog", "SkewNumber", c=> c.Int());
        }

        public override void Down()
        {
            DropColumn("ProductCatalog", "SkewNumber");
        }
    }
}
