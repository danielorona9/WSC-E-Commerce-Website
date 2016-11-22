using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class OrderRequest
    {
        public int OrderRequestID { get; set; }
        public int ProductCatalogID { get; set; }
        public int PurchaseOrdersID { get; set; }
        public int Quantity { get; set; }
        public string Content { get; set; }
        public decimal Price { get; set; }

        public virtual ProductCatalog ProductCatalog { get; set; }
        public virtual PurchaseOrders PurchaseOrders { get; set; }
    }
}