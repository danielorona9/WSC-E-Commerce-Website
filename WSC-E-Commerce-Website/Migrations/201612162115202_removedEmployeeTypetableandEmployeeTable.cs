namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedEmployeeTypetableandEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "EmployeeTypeID", "dbo.EmployeeType");
            DropForeignKey("dbo.PurchaseOrders", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.PurchaseOrders", new[] { "EmployeeID" });
            DropIndex("dbo.Employee", new[] { "EmployeeTypeID" });
            DropColumn("dbo.PurchaseOrders", "EmployeeID");
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeeType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeType",
                c => new
                    {
                        EmployeeTypeID = c.Int(nullable: false, identity: true),
                        EmployeeTypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeTypeID);
            
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
                .PrimaryKey(t => t.EmployeeID);
            
            AddColumn("dbo.PurchaseOrders", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "EmployeeTypeID");
            CreateIndex("dbo.PurchaseOrders", "EmployeeID");
            AddForeignKey("dbo.PurchaseOrders", "EmployeeID", "dbo.Employee", "EmployeeID", cascadeDelete: true);
            AddForeignKey("dbo.Employee", "EmployeeTypeID", "dbo.EmployeeType", "EmployeeTypeID", cascadeDelete: true);
        }
    }
}
