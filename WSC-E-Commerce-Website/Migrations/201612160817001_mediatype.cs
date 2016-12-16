namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mediatype : DbMigration
    {
        public override void Up()
        {


            Sql(@"INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Pending')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Cancelled')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Validated')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'In Progress')
                INSERT INTO [dbo].[PurchaseOrderStatus] ([StatusName]) VALUES ( N'Shipped')");

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
