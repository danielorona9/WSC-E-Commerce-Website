namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobtypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO[dbo].[JobTypes] ([JobTypeName]) VALUES( N'Printing')
                INSERT INTO[dbo].[JobTypes] ([JobTypeName]) VALUES( N'Engraving')");
        }
        
        public override void Down()
        {
        }
    }
}
