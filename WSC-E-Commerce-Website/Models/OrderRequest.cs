using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class OrderRequest
    {
        public int OrderRequestID { get; set; }

        public int ProductCatalogID { get; set; }

        public int PurchaseOrdersID { get; set; }

        [Required(ErrorMessage ="Enter quantity amount")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Enter the content")]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //connected tables on the one side
        public virtual ProductCatalog ProductCatalog { get; set; }
        public virtual PurchaseOrders PurchaseOrders { get; set; }
    }
}