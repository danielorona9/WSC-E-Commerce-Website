using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class Billing
    {
        [Display(Name = "Billing Number")]
        public int BillingID { get; set; }

        public int PurchaseOrdersID { get; set; }

        [Display(Name ="Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}",ApplyFormatInEditMode =true)]
        public DateTime BillingDueDate { get; set; }

        [Display(Name = "Date Paid")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BillingPaiddueDate { get; set; }

        [Display(Name ="Balance")]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Display(Name ="Amount Paid")]
        [DataType(DataType.Currency)]
        public decimal PaidAmount { get; set; }


        public virtual PurchaseOrders PurchaseOrders { get; set; }
    }
}