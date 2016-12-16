namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateTables : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[CreditCardType] ([CreditCardTypeName]) VALUES ( N'Visa')
                INSERT INTO [dbo].[CreditCardType] ([CreditCardTypeName]) VALUES (N'MasterCard')
                INSERT INTO [dbo].[CreditCardType] ([CreditCardTypeName]) VALUES (N'American Express')");    

            Sql(@"
                INSERT INTO[dbo].[JobTypes] ([JobTypeName]) VALUES( N'Printing')
                INSERT INTO[dbo].[JobTypes] ([JobTypeName]) VALUES( N'Engraving')");

            Sql(@"INSERT INTO [dbo].[MediaTypes] ([MediaTypeName]) VALUES (N'Cloth')
                  INSERT INTO[dbo].[MediaTypes]([MediaTypeName]) VALUES(N'Plaque')
                  INSERT INTO[dbo].[MediaTypes] ([MediaTypeName]) VALUES(N'Trophy')");

            Sql(@"INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Pending')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Cancelled')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Validated')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'In Progress')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Shipped')");


          
            Sql("INSERT INTO [dbo].[User] ([UserID], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6046e11d-9ae2-42f5-9b90-e2e868147fad', N'DANIEL', N'ORONA', N'176 e. ellis st.', NULL, N'long beach', N'CA', 90805, N'admin@WSC.com', 0, N'AP1dwkctKUt7PpKD+9G0WxgphHpML9oKqX0pH4Bm+8qCHg2d+PMRfyshmBNXYmVhFA==', N'15c453e0-9faa-49e7-9c46-e842fe240d35', NULL, 0, 0, NULL, 1, 0, N'admin@WSC.com')");
        

            Sql("INSERT INTO[dbo].[Roles] ([RoleID], [Name], [Discriminator]) VALUES(N'188f39d5-d1c9-4a92-82a3-b8caae1eebec', N'Sales Clerk', N'IdentityRole')");
            Sql("INSERT INTO[dbo].[Roles] ([RoleID], [Name], [Discriminator]) VALUES(N'20628b9c-c516-401e-983c-660b0087bcfe', N'Admin', N'IdentityRole') ");
            Sql("INSERT INTO[dbo].[Roles] ([RoleID], [Name], [Discriminator]) VALUES(N'b4d7000c-3726-4be0-900c-e7e9591ff213', N'Operations Manager', N'IdentityRole') ");

            Sql("INSERT INTO[dbo].[UserRole] ([UserId], [RoleId], [ApplicationUser_Id]) VALUES(N'6046e11d-9ae2-42f5-9b90-e2e868147fad', N'20628b9c-c516-401e-983c-660b0087bcfe', NULL)");

        }

        public override void Down()
        {
        }
    }
}
