using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class ProductCatalog
    {
        public int ProductCatalogID { get; set; }
        public int JobTypeID { get; set; }
        public int MediaTypeID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockAvailable { get; set; }
        public string ProductImage { get; set; }

        public virtual JobType JobType { get; set; }
        public virtual MediaType MediaType { get; set; }
    }
}