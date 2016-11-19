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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public char State { get; set; }
        public int Zip { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM-dd-yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Registered Date")]
        public DateTime RegisteredDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:MM-dd-yyyy", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

        public bool Locked { get; set; }
    }
}