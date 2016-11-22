using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class JobTypes
    {
        public int JobTypeID { get; set; }
        public string JobTypeName { get; set; }

        public virtual ICollection<ProductCatalog> ProductCatalog { get; set; }
    }
}