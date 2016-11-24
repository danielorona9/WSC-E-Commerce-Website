using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        public int EmployeeTypeID { get; set; }

        [Required (ErrorMessage = "Enter employee first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter employee last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Locked { get; set; }

        //connected tables that are on the one side
        public virtual EmployeeType EmployeeType { get; set; }

        //connected table that are on the many side
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }

    }
}