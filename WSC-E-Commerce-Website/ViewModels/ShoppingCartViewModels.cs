using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<PurchaseOrders> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    
    }

    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }

    }
}