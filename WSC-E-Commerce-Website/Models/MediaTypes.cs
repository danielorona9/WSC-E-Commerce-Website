using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WSC_E_Commerce_Website.Models
{
    public class MediaTypes
    {
        public int MediaTypeID { get; set; }

        [Display(Name = "Media Type")]
        public string MediaTypeName { get; set; }

        //connected tables on the many side
        public virtual ICollection<ProductCatalog> ProductCatalog { get; set; }
    }
}