using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class CreditCardType
    {
        public int CreditCardTypeID { get; set;}

        [Required(ErrorMessage = "please select a credit card type")]
        [Display(Name = "Credit Card Type")]
        public string CreditCardTypeName { get; set; }

        //connected tables on many side
        public virtual ICollection<BillingInfo> BillingInfo { get; set; }
    }
}