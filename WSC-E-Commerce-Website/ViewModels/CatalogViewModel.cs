using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.ViewModels
{
    public class CatalogViewModel
    {
        public List<ProductCatalog> Items { get; set; }
        public List<MediaTypes> MediaType { get; set; }
        public List<JobTypes> JobType { get; set; }
        
        public int selectMediaTypeId { get; set; }
        public int selectJobTypeId { get; set; }
    }
}