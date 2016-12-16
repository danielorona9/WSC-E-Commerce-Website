using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.ViewModels
{
    public class ShoppingCart
    {


    }

    public class OrderViewModel
    {
        public ApplicationUser user { get; set; }

        public BillingInfo billInfo { get; set; }
    }
}