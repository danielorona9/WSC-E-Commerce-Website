using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSC_E_Commerce_Website.Models
{
    [Table("PurchaseOrders")]
    public class PurchaseOrders
    {
        [Key]
        public string PurchaseOrdersID { get; set; }

        [ForeignKey("PurchaseOrderStatus")]
        public int PurchaseOrderStatuesID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [ForeignKey("OrderType")]
        public int OrderTypeID { get; set; }     

        [Display(Name = "Date Ordered")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Display(Name ="Deposit Amount")]
        [DataType(DataType.Currency)]
        public decimal Deposit { get; set; }

        public string ApplicationUserID { get; set; }

        //connected tables on the one side
        public virtual PurchaseOrderStatus PurchaseOrderStatus {get; set;}
        public virtual Employee Employee { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //connected tables on the many side
        public virtual ICollection<Billing> Billing { get; set; }
        public virtual ICollection<OrderRequest> OrderRequest { get; set; }
    
    }
}