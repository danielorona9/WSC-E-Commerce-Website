using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSC_E_Commerce_Website.Models
{
    [Table("BillingInfo")]
    public class BillingInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillingInfoID { get; set; }

        [ForeignKey("Customers")]
        public int CustomerID { get; set; }  

        [ForeignKey("CreditCardType")]
        public int CreditCardTypeID { get; set; }

        [Required(ErrorMessage = "Enter Credit Card number")]    
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