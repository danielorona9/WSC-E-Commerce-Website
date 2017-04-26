using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<ProductCatalog> Items { get; set; }
       // public string MediaTypeName { get; set; }
       // public string JobTypeName { get; set; }
    }
}