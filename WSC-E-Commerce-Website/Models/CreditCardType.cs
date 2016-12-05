using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSC_E_Commerce_Website.Models
{
    [Table("CreditCardType")]
    public class CreditCardType
    {
        [Key]
        public int CreditCardTypeId { get; set;}

        [Required(ErrorMessage = "please select a credit card type")]
        [Display(Name = "Credit Card Type")]
        public string CreditCardTypeName { get; set; }

        //connected tables on many side
        public virtual ICollection<BillingInfo> BillingInfo { get; set; }
    }
}