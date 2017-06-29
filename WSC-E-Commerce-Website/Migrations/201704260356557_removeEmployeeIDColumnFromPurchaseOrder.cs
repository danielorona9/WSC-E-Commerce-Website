using System.Data.Entity.Core.Common.CommandTrees;

namespace WSC_E_Commerce_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeEmployeeIDColumnFromPurchaseOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseOrders","EmployeeID","dbo.Employee");
            DropIndex("dbo.PurchaseOrders", new[] { "EmployeeID" });
            DropColumn("dbo.PurchaseOrders","EmployeeID");
            
        }
        
        public override void Down()
        {
           
            AddColumn("dbo.PurchaseOrders","EmployeeID", s=>s.Int(nullable: false));
            CreateIndex("dbo.PurchaseOrders","EmployeeID");
            AddForeignKey("dbo.PurchaseOrders", "EmployeeID", "dbo.Employee");
        }
    }
}
