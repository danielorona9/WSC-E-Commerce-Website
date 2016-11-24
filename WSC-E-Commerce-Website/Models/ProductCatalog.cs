using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class ProductCatalog
    {
        public int ProductCatalogID { get; set; }

        public int JobTypeID { get; set; }

        public int MediaTypeID { get; set; }

        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public int StockAvailable { get; set; }

        [Display(Name = "Image")]
        public string ProductImage { get; set; }

        //connected tables that are on the one side
        public virtual JobTypes JobType { get; set; }
        public virtual MediaTypes MediaType { get; set; }
    }
}