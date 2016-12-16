namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mediatype : DbMigration
    {
        public override void Up()
        {

            Sql(@"INSERT INTO [dbo].[MediaTypes] ([MediaTypeName]) VALUES (N'Cloth')
                  INSERT INTO[dbo].[MediaTypes]([MediaTypeName]) VALUES(N'Plaque')
                  INSERT INTO[dbo].[MediaTypes] ([MediaTypeName]) VALUES(N'Trophy')");

            Sql(@"
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 1, 1, CAST(19.99 AS Decimal(18, 2)), N'Blank Black Shirt', 100, N'~/content/images/CatalogProducts/BlackShirt.jpg')
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 1, 1, CAST(19.99 AS Decimal(18, 2)), N'Blank Grey Shirt', 100, N'~/content/images/CatalogProducts/GreyShirt.jpg')
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 1, 1, CAST(19.99 AS Decimal(18, 2)), N'Blank Blue Shirt', 100, N'~/content/images/CatalogProducts/BlueShirt.jpg')
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 2, 2, CAST(29.99 AS Decimal(18, 2)), N'Blank Gold Plaque', 100, N'~/content/images/CatalogProducts/GoldPLaques.jpg')
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 2, 2, CAST(29.99 AS Decimal(18, 2)), N'Blank Silver Plaque', 100, N'~/content/images/CatalogProducts/SilverPlaque.jpg')
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 2, 2, CAST(29.99 AS Decimal(18, 2)), N'Blank group Plaque', 100, N'~/content/images/CatalogProducts/GroupPlaque.jpg')
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 2, 3, CAST(29.99 AS Decimal(18, 2)), N'Blank Gold Trophy', 100, N'~/content/images/CatalogProducts/GoldTrophy.jpg')
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 2, 3, CAST(29.99 AS Decimal(18, 2)), N'Blank Silver Trophy', 100, N'~/content/images/CatalogProducts/SilverTrophy.jpg')
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage]) VALUES ( 2, 3, CAST(29.99 AS Decimal(18, 2)), N'Blank Bronze Trophy', 100, N'~/content/images/CatalogProducts/BronzeTrophy.jpg')
                ");

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
