using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class Billing
    {
        public int BillingID { get; set; }
        public int PurchaseOrdersID { get; set; }
        public DateTime BillingDueDate { get; set; }
        public DateTime BillingPaiddueDate { get; set; }
        public decimal Balance { get; set; }
        public decimal PaidAmount { get; set; }

        public virtual PurchaseOrders PurchaseOrders { get; set; }
    }
}