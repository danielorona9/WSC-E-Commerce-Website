using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    [Table("BillingInfo")]
    public class BillingInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillingInfoID { get; set; }

        [ForeignKey("CreditCardType")]
        public int CreditCardTypeID { get; set; }

        [Required(ErrorMessage = "Enter Credit Card number")]
        [Display(Name = "Credit Card Number")]
        public int CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Enter expiration date")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        public string ApplicationUserID { get; set; }

        //connected to tables that are the one side
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual CreditCardType CreditCardType { get; set; }

    }
}