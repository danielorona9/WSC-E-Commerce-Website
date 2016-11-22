using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class EmployeeType
    {
        public int EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }

        public ICollection<Employee> Employee { get; set; }

    }
}