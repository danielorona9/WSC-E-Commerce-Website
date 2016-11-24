﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class EmployeeType
    {
        public int EmployeeTypeID { get; set; }

        [Required(ErrorMessage = "Enter employee title")]
        [Display(Name ="Employee Title")]
        public string EmployeeTypeName { get; set; }

        //connected tables that are on the many side
        public ICollection<Employee> Employee { get; set; }

    }
}