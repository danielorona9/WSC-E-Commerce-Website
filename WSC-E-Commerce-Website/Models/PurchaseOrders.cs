using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class PurchaseOrders
    {
        public int PurchaseOrdersID { get; set; }
        public int PurchaseOrderStatuesID { get; set; }
        public int EmployeeID { get; set; }
        public int OrderTypeID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public decimal Deposit { get; set; }

        public virtual PurchaseOrderStatus PurchaseOrderStatus {get; set;}
        public virtual Employee Employee { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Customers Customers { get; set; }

        public virtual ICollection<Billing> Billing { get; set; }
    
    }
}