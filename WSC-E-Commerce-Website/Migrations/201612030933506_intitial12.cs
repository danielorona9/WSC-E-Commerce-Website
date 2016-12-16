namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        PurchaseOrdersID = c.String(nullable: false, maxLength:128),
                        PurchaseOrderStatuesID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        OrderTypeID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PurchaseOrdersID)
                .ForeignKey("dbo.User", t => t.ApplicationUserID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.OrderType", t => t.OrderTypeID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrderStatus", t => t.PurchaseOrderStatuesID, cascadeDelete: true)
                .Index(t => t.PurchaseOrderStatuesID)
                .Index(t => t.EmployeeID)
                .Index(t => t.OrderTypeID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Billing",
                c => new
                    {
                        BillingID = c.Int(nullable: false, identity: true),
                        PurchaseOrdersID = c.String(nullable: false, maxLength:128),
                        BillingDueDate = c.DateTime(nullable: false),
                        BillingPaiddueDate = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BillingID)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrdersID, cascadeDelete: true)
                .Index(t => t.PurchaseOrdersID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeTypeID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Locked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.EmployeeType", t => t.EmployeeTypeID, cascadeDelete: true)
                .Index(t => t.EmployeeTypeID);
            
            CreateTable(
                "dbo.EmployeeType",
                c => new
                    {
                        EmployeeTypeID = c.Int(nullable: false, identity: true),
                        EmployeeTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeTypeID);
            
            CreateTable(
                "dbo.OrderRequest",
                c => new
                    {
                        OrderRequestID = c.Int(nullable: false, identity: true),
                        ProductCatalogID = c.Int(nullable: false),
                        PurchaseOrdersID = c.String(nullable: false, maxLength:128),
                        Quantity = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderRequestID)
                .ForeignKey("dbo.ProductCatalog", t => t.ProductCatalogID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrdersID, cascadeDelete: true)
                .Index(t => t.ProductCatalogID)
                .Index(t => t.PurchaseOrdersID);
            
            CreateTable(
                "dbo.ProductCatalog",
                c => new
                    {
                        ProductCatalogID = c.Int(nullable: false, identity: true),
                        JobTypeID = c.Int(nullable: false),
                        MediaTypeID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(nullable: false),
                        StockAvailable = c.Int(nullable: false),
                        ProductImage = c.String(),
                    })
                .PrimaryKey(t => t.ProductCatalogID)
                .ForeignKey("dbo.JobTypes", t => t.JobTypeID, cascadeDelete: true)
                .ForeignKey("dbo.MediaTypes", t => t.MediaTypeID, cascadeDelete: true)
                .Index(t => t.JobTypeID)
                .Index(t => t.MediaTypeID);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        JobTypeID = c.Int(nullable: false, identity: true),
                        JobTypeName = c.String(),
                    })
                .PrimaryKey(t => t.JobTypeID);
            
            CreateTable(
                "dbo.MediaTypes",
                c => new
                    {
                        MediaTypeID = c.Int(nullable: false, identity: true),
                        MediaTypeName = c.String(),
                    })
                .PrimaryKey(t => t.MediaTypeID);
            
            CreateTable(
                "dbo.OrderType",
                c => new
                    {
                        OrderTypeID = c.Int(nullable: false, identity: true),
                        OrderTypeName = c.String(),
                    })
                .PrimaryKey(t => t.OrderTypeID);
            
            CreateTable(
                "dbo.PurchaseOrderStatus",
                c => new
                    {
                        PurchaseOrderStatusID = c.Int(nullable: false, identity:true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseOrderStatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrders", "PurchaseOrderStatuesID", "dbo.PurchaseOrderStatus");
            DropForeignKey("dbo.PurchaseOrders", "OrderTypeID", "dbo.OrderType");
            DropForeignKey("dbo.OrderRequest", "PurchaseOrdersID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.OrderRequest", "ProductCatalogID", "dbo.ProductCatalog");
            DropForeignKey("dbo.ProductCatalog", "MediaTypeID", "dbo.MediaTypes");
            DropForeignKey("dbo.ProductCatalog", "JobTypeID", "dbo.JobTypes");
            DropForeignKey("dbo.PurchaseOrders", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "EmployeeTypeID", "dbo.EmployeeType");
            DropForeignKey("dbo.Billing", "PurchaseOrdersID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "ApplicationUserID", "dbo.User");
            DropIndex("dbo.ProductCatalog", new[] { "MediaTypeID" });
            DropIndex("dbo.ProductCatalog", new[] { "JobTypeID" });
            DropIndex("dbo.OrderRequest", new[] { "PurchaseOrdersID" });
            DropIndex("dbo.OrderRequest", new[] { "ProductCatalogID" });
            DropIndex("dbo.Employee", new[] { "EmployeeTypeID" });
            DropIndex("dbo.Billing", new[] { "PurchaseOrdersID" });
            DropIndex("dbo.PurchaseOrders", new[] { "ApplicationUserID" });
            DropIndex("dbo.PurchaseOrders", new[] { "OrderTypeID" });
            DropIndex("dbo.PurchaseOrders", new[] { "EmployeeID" });
            DropIndex("dbo.PurchaseOrders", new[] { "PurchaseOrderStatuesID" });
            DropTable("dbo.PurchaseOrderStatus");
            DropTable("dbo.OrderType");
            DropTable("dbo.MediaTypes");
            DropTable("dbo.JobTypes");
            DropTable("dbo.ProductCatalog");
            DropTable("dbo.OrderRequest");
            DropTable("dbo.EmployeeType");
            DropTable("dbo.Employee");
            DropTable("dbo.Billing");
            DropTable("dbo.PurchaseOrders");
        }
    }
}
