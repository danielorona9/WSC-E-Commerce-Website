using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSC_E_Commerce_Website.DAL;

namespace WSC_E_Commerce_Website.Controllers
{
    public class HomeController : Controller
    {
        private EcommerceStoreDB_Context db = new EcommerceStoreDB_Context();

        // GET: ProductCatalog  
        public ActionResult Index()
        {                 
            {
                var productCatalog = db.ProductCatalog.Include(p => p.JobType).Include(p => p.MediaType);
                return View(productCatalog.ToList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}