using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WSC_E_Commerce_Website.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
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
        [StringLength(30)]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Enter your City")]
        [Display(Name = "City")]
        [StringLength(30)]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter your State")]
        [Display(Name = "State")]
        [StringLength(2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter your ZipCode")]
        [Display(Name = "ZipCode")]
        public int Zip { get; set; }

        //[Display(Name = "Registered Date")]
        //public DateTime RegisteredDate { get; set; }

        //[Display(Name = "Modified Date")]
        //public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BillingInfo> BillingInfo { get; set; }
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

       
    }

   
}