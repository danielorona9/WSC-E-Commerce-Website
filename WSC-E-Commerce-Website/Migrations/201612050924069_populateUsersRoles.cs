namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateUsersRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[User] ([UserID], [FirstName], [LastName], [Address1], [Address2], [City], [State], [Zip], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6046e11d-9ae2-42f5-9b90-e2e868147fad', N'DANIEL', N'ORONA', N'176 e. ellis st.', NULL, N'long beach', N'CA', 90805, N'admin@WSC.com', 0, N'AP1dwkctKUt7PpKD+9G0WxgphHpML9oKqX0pH4Bm+8qCHg2d+PMRfyshmBNXYmVhFA==', N'15c453e0-9faa-49e7-9c46-e842fe240d35', NULL, 0, 0, NULL, 1, 0, N'admin@WSC.com')");
            Sql("INSERT INTO [dbo].[Roles] ([RoleID], [Name]) VALUES (N'a618e06b-7b6e-4614-9a86-f9ed5b25758c', N'CanManageCatalog') ");
            Sql("INSERT INTO [dbo].[UserRole] ([UserId], [RoleId]) VALUES (N'6046e11d-9ae2-42f5-9b90-e2e868147fad', N'a618e06b-7b6e-4614-9a86-f9ed5b25758c') ");
        }
        
        public override void Down()
        {
        }
    }
}
