namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMediaTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[MediaTypes] ([MediaTypeName]) VALUES (N'Cloth')
                  INSERT INTO[dbo].[MediaTypes]([MediaTypeName]) VALUES(N'Plaque')
                  INSERT INTO[dbo].[MediaTypes] ([MediaTypeName]) VALUES(N'Trophy')");
        }
        
        public override void Down()
        {
        }
    }
}
