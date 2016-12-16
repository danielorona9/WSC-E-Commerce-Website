namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateProductCatalog : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 1, 1, CAST(19.99 AS Decimal(18, 2)), N'Blank Black Shirt', 100, N'~/content/images/CatalogProducts/BlackShirt.jpg', 111)
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 1, 1, CAST(19.99 AS Decimal(18, 2)), N'Blank Grey Shirt', 100, N'~/content/images/CatalogProducts/GreyShirt.jpg', 211)
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 1, 1, CAST(19.99 AS Decimal(18, 2)), N'Blank Blue Shirt', 100, N'~/content/images/CatalogProducts/BlueShirt.jpg', 311)
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 2, 2, CAST(29.99 AS Decimal(18, 2)), N'Blank Gold Plaque', 100, N'~/content/images/CatalogProducts/GoldPLaques.jpg', 422)
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 2, 2, CAST(29.99 AS Decimal(18, 2)), N'Blank Silver Plaque', 100, N'~/content/images/CatalogProducts/SilverPlaque.jpg', 522)
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 2, 2, CAST(29.99 AS Decimal(18, 2)), N'Blank group Plaque', 100, N'~/content/images/CatalogProducts/GroupPlaque.jpg', 622)
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 2, 3, CAST(29.99 AS Decimal(18, 2)), N'Blank Gold Trophy', 100, N'~/content/images/CatalogProducts/GoldTrophy.jpg', 723)
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 2, 3, CAST(29.99 AS Decimal(18, 2)), N'Blank Silver Trophy', 100, N'~/content/images/CatalogProducts/SilverTrophy.jpg', 823)
                INSERT INTO [dbo].[ProductCatalog] ( [JobTypeID], [MediaTypeID], [Price], [Description], [StockAvailable], [ProductImage],[SkewNumber]) VALUES ( 2, 3, CAST(29.99 AS Decimal(18, 2)), N'Blank Bronze Trophy', 100, N'~/content/images/CatalogProducts/BronzeTrophy.jpg', 923)
                ");
        }
        
        public override void Down()
        {
        }
    }
}
