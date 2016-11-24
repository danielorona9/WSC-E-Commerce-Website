using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class BillingInfo
    {
        
        public int BillingInfoID { get; set; }

        public int CustomerID { get; set; }  

        public int CreditCardTypeID { get; set; }

        [Required(ErrorMessage = "Enter Credit Card number")]
        [StringLength(16)]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit Card Number")]
        public int CreditNumber { get; set; }

        [Required(ErrorMessage = "Enter expiration date")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        //connected to tables that are the one side
        public virtual Customers Customers { get; set; }
        public virtual CreditCardType CreditCardType { get; set; }
    }
}