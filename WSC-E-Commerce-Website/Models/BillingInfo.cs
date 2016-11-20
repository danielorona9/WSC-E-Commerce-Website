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

        [Required(ErrorMessage = "Enter Credit Card number")]
        [StringLength(16)]
        [Display(Name = "Credit Card Number")]
        public int CreditNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        //connected to tables that are not one to many or FK
        public virtual Customers Customers { get; set; }

    }
}