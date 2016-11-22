using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class MediaTypes
    {
        public int MediaTypeID { get; set; }
        public string MediaTypeName { get; set; }

        public virtual ICollection<ProductCatalog> ProductCatalog { get; set; }
    }
}