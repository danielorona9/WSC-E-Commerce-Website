using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.DAL
{
    public class EcommerceStoreDB_Context
    {
        public DbSet<CreditCardType> CreditCardType {get; set;}
        public DbSet<BillingInfo> BillingInfo { get; set; }
        public DbSet<Customers>Customers { get; set; }
    }
}