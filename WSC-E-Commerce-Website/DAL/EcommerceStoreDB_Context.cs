using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.DAL
{
    public class EcommerceStoreDB_Context : DbContext
    {
        public DbSet<CreditCardType> CreditCardType {get; set;}
        public DbSet<BillingInfo> BillingInfo { get; set; }
        public DbSet<Customers>Customers { get; set; }
        public DbSet<Billing>Billing { get; set; }
        public DbSet<Employee>Employee { get; set; }
        public DbSet<EmployeeType> EmployeeType { get; set; }
        public DbSet<JobTypes> JobTypes { get; set; }
        public DbSet<MediaTypes> MediaTypes { get; set; }
        public DbSet<OrderRequest> OrderRequest { get; set; }
        public DbSet<OrderType>OrderType { get; set; }
        public DbSet<ProductCatalog>ProductCatalog { get; set; }
        public DbSet<PurchaseOrders>PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderStatus> PurchaseOrderStatus { get; set; }

    }
}