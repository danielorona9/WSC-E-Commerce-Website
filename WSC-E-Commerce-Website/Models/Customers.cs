using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class Customers
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter your Address")]
        [Display(Name = "Address1")]
        [StringLength(30)]
        public string Address1 { get; set; }

        [Display(Name = "Address2")]
        [StringLength(50)]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Enter your City")]
        [Display(Name = "City")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter your State")]
        [Display(Name = "State")]
        [StringLength(30)]
        public char State { get; set; }

        [Required(ErrorMessage = "Enter your ZipCode")]
        [Display(Name = "ZipCode")]
        [StringLength(5)]
        public int Zip { get; set; }

        [Required(ErrorMessage = "Enter your Email address")]
        [Display(Name = "Email")]
        [StringLength(65)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your username")]
        [Display(Name = "Username")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [Display(Name = "Password")]
        [StringLength(30)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registered Date")]
        public DateTime RegisteredDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Locked")]
        public bool Locked { get; set; }

        //connected tables that are one to many
        public virtual ICollection<BillingInfo> BillingInfo { get; set; }
    }
}