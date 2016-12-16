namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatetable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[CreditCardType] ([CreditCardTypeName]) VALUES ( N'Visa')
                INSERT INTO [dbo].[CreditCardType] ([CreditCardTypeName]) VALUES (N'MasterCard')
                INSERT INTO [dbo].[CreditCardType] ([CreditCardTypeName]) VALUES (N'American Express')");

            


        }

        public override void Down()
        {
        }
    }
}
