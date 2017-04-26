namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingInfo",
                c => new
                {
                    BillingInfoID = c.Int(nullable: false, identity: true),
                    CreditCardTypeID = c.Int(nullable: false),
                    CreditCardNumber = c.Int(nullable: false),
                    ExpirationDate = c.DateTime(nullable: false),
                    ApplicationUserID = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.BillingInfoID)
                .ForeignKey("dbo.User", t => t.ApplicationUserID, cascadeDelete: true)
                .ForeignKey("dbo.CreditCardType", t => t.CreditCardTypeID, cascadeDelete: true)
                .Index(t => t.CreditCardTypeID)
                .Index(t => t.ApplicationUserID);

            CreateTable(
                "dbo.User",
                c => new
                {
                    UserID = c.String(nullable: false, maxLength: 128),
                    FirstName = c.String(nullable: false, maxLength: 30),
                    LastName = c.String(nullable: false, maxLength: 30),
                    Address1 = c.String(nullable: false, maxLength: 30),
                    Address2 = c.String(maxLength: 30),
                    City = c.String(nullable: false, maxLength: 30),
                    State = c.String(nullable: false, maxLength: 2),
                    Zip = c.Int(nullable: false),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.UserClaim",
                c => new
                {
                    UserClaimID = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.UserClaimID)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.UserLogin",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.ApplicationUser_Id)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationUser_Id);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    OrderDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.User", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);

            CreateTable(
                "dbo.OrderRequest",
                c => new
                {
                    OrderRequestID = c.Int(nullable: false, identity: true),
                    ProductCatalogID = c.Int(nullable: false),
                    PurchaseOrdersID = c.Int(nullable: false),
                    OrderId = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Content = c.String(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.OrderRequestID)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCatalog", t => t.ProductCatalogID, cascadeDelete: false)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrdersID, cascadeDelete: true)
                .Index(t => t.ProductCatalogID)
                .Index(t => t.PurchaseOrdersID)
                .Index(t => t.OrderId);

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
                "dbo.PurchaseOrders",
                c => new
                {
                    PurchaseOrdersID = c.Int(nullable: false, identity: true),
                    PurchaseOrderStatuesID = c.Int(nullable: false),
                    EmployeeID = c.Int(nullable: false),
                    CartID = c.String(),
                    ProductCatalogId = c.Int(nullable: false),
                    OrderDate = c.DateTime(nullable: false),
                    Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Deposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ApplicationUserID = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.PurchaseOrdersID)
                .ForeignKey("dbo.User", t => t.ApplicationUserID)
                .ForeignKey("dbo.Employee", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.ProductCatalog", t => t.ProductCatalogId, cascadeDelete: false)
                .ForeignKey("dbo.PurchaseOrderStatus", t => t.PurchaseOrderStatuesID, cascadeDelete: true)
                .Index(t => t.PurchaseOrderStatuesID)
                .Index(t => t.EmployeeID)               
                .Index(t => t.ProductCatalogId)
                .Index(t => t.ApplicationUserID);

            CreateTable(
                "dbo.Billing",
                c => new
                {
                    BillingID = c.Int(nullable: false, identity: true),
                    PurchaseOrdersID = c.Int(nullable: false),
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
                "dbo.PurchaseOrderStatus",
                c => new
                {
                    PurchaseOrderStatusID = c.Int(nullable: false, identity: true),
                    StatusName = c.String(),
                })
                .PrimaryKey(t => t.PurchaseOrderStatusID);

            CreateTable(
                "dbo.UserRole",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.ApplicationUser_Id);

            CreateTable(
                "dbo.CreditCardType",
                c => new
                {
                    CreditCardTypeId = c.Int(nullable: false, identity: true),
                    CreditCardTypeName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.CreditCardTypeId);

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    RoleID = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.RoleID)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

        }

        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.BillingInfo", "CreditCardTypeID", "dbo.CreditCardType");
            DropForeignKey("dbo.BillingInfo", "ApplicationUserID", "dbo.User");
            DropForeignKey("dbo.UserRole", "ApplicationUser_Id", "dbo.User");
            DropForeignKey("dbo.UserLogin", "ApplicationUser_Id", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderRequest", "PurchaseOrdersID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "PurchaseOrderStatuesID", "dbo.PurchaseOrderStatus");
            DropForeignKey("dbo.PurchaseOrders", "ProductCatalogId", "dbo.ProductCatalog");
            DropForeignKey("dbo.PurchaseOrders", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Employee", "EmployeeTypeID", "dbo.EmployeeType");
            DropForeignKey("dbo.Billing", "PurchaseOrdersID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrders", "ApplicationUserID", "dbo.User");
            DropForeignKey("dbo.OrderRequest", "ProductCatalogID", "dbo.ProductCatalog");
            DropForeignKey("dbo.ProductCatalog", "MediaTypeID", "dbo.MediaTypes");
            DropForeignKey("dbo.ProductCatalog", "JobTypeID", "dbo.JobTypes");
            DropForeignKey("dbo.OrderRequest", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ApplicationUserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Employee", new[] { "EmployeeTypeID" });
            DropIndex("dbo.Billing", new[] { "PurchaseOrdersID" });
            DropIndex("dbo.PurchaseOrders", new[] { "ApplicationUserID" });
            DropIndex("dbo.PurchaseOrders", new[] { "ProductCatalogId" });
            DropIndex("dbo.PurchaseOrders", new[] { "EmployeeID" });
            DropIndex("dbo.PurchaseOrders", new[] { "PurchaseOrderStatuesID" });
            DropIndex("dbo.ProductCatalog", new[] { "MediaTypeID" });
            DropIndex("dbo.ProductCatalog", new[] { "JobTypeID" });
            DropIndex("dbo.OrderRequest", new[] { "OrderId" });
            DropIndex("dbo.OrderRequest", new[] { "PurchaseOrdersID" });
            DropIndex("dbo.OrderRequest", new[] { "ProductCatalogID" });
            DropIndex("dbo.Orders", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.BillingInfo", new[] { "ApplicationUserID" });
            DropIndex("dbo.BillingInfo", new[] { "CreditCardTypeID" });
            DropTable("dbo.Roles");
            DropTable("dbo.CreditCardType");
            DropTable("dbo.UserRole");
            DropTable("dbo.PurchaseOrderStatus");       
            DropTable("dbo.EmployeeType");
            DropTable("dbo.Employee");
            DropTable("dbo.Billing");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.MediaTypes");
            DropTable("dbo.JobTypes");
            DropTable("dbo.ProductCatalog");
            DropTable("dbo.OrderRequest");
            DropTable("dbo.Orders");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.BillingInfo");
        }
    }
}
