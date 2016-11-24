using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Date Ordered")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Display(Name ="Deposit Amount")]
        [DataType(DataType.Currency)]
        public decimal Deposit { get; set; }

        //connected tables on the one side
        public virtual PurchaseOrderStatus PurchaseOrderStatus {get; set;}
        public virtual Employee Employee { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Customers Customers { get; set; }

        //connected tables on the many side
        public virtual ICollection<Billing> Billing { get; set; }
        public virtual ICollection<OrderRequest> OrderRequest { get; set; }
    
    }
}