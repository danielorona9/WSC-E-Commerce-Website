using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int EmployeeTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Locked { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }

        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; }

    }
}