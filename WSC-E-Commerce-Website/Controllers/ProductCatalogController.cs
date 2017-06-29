using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using System.Web.UI.WebControls;
using WSC_E_Commerce_Website.DAL;
using WSC_E_Commerce_Website.Models;
using WSC_E_Commerce_Website.ViewModels;

namespace WSC_E_Commerce_Website.Controllers
{
    public class ProductCatalogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductCatalog
        public ActionResult Index()
        {
            var productCatalog = db.ProductCatalog.Include(p => p.JobType).Include(p => p.MediaType);
            return View(productCatalog.ToList());
         
        }

        // GET: ProductCatalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductCatalog productCatalog = db.ProductCatalog.Find(id);

            if (productCatalog == null)
            {
                return HttpNotFound();
            }

            return View(productCatalog);
        }
        //GET: ProductCatalog/ProductDetails/id
        public ActionResult ProductDetail(int? id)
        {
            
         var product =
                db.ProductCatalog
                .Include(p => p.MediaType)
                .Include(p => p.JobType)
                .Single(p => p.ProductCatalogID == id.Value);

            if (id == null)
            {
                return HttpNotFound();
            }
                    
            return View("ProductDetail", product);
        }
        //****************************************************

        //consumer index Page
        //GET: ProductCatalog/CatalogList
        public ActionResult CatalogList()
        {
            var catalog = new CatalogViewModel
            {
                Items = new List<ProductCatalog>(db.ProductCatalog.Include(p => p.JobType).Include(p=>p.MediaType)),
                JobType = new List<JobTypes>(db.JobTypes).ToList(),            
                MediaType = new List<MediaTypes>(db.MediaTypes).ToList()            
           
            };
            

            return View("Catalog", catalog);
        }

        ////get catalog list
        //public ActionResult GetCatalog()
        //{
        //    var items = new Catalog();
        //   var products =  items.GetCatalogItems();

        //    var viewModel = new CatalogViewModel
        //    {
        //        Items = items.GetCatalogItems(),


        //    };
        //    //var productCatalog =
        //    //    db.ProductCatalog
        //    //        .Include(p => p.JobType)
        //    //        .Include(p => p.MediaType);

        //    return Json(viewModel, JsonRequestBehavior.AllowGet);
            
        //}

        //GET: SortByMediaType/id

        public ActionResult SortByMediaType(int? id)
        {
           
            if (id == null)
            {
                return  new HttpStatusCodeResult((HttpStatusCode.BadRequest));
            }
         
            var product = new CatalogViewModel()
            {
                Items = db.ProductCatalog
                     .Include(p => p.MediaType)
                     .Include(p => p.JobType)
                     .Where(p => p.MediaTypeID == id.Value).ToList(),

                JobType = new List<JobTypes>(db.JobTypes).ToList(),

                MediaType = new List<MediaTypes>(db.MediaTypes).ToList()
            };

            return View("Catalog", product);
        }

        public ActionResult FilterOff()
        {
        
            var product = new CatalogViewModel()
            {
                Items = db.ProductCatalog
                    .Include(p => p.JobType)
                    .Include(p => p.MediaType).ToList(),

                JobType = new List<JobTypes>(db.JobTypes).ToList(),

                MediaType = new List<MediaTypes>(db.MediaTypes).ToList()
            };

            return View("Catalog", product);
        }

        
        public ActionResult SortByJobType(CatalogViewModel model)
        {
            try
            {
                var id = model.selectJobTypeId;

                if (id == 0)
                {
                    return RedirectToAction("CatalogList");
                }
                else
                {
                    var product = new CatalogViewModel()
                    {
                        Items = db.ProductCatalog
                            .Include(p => p.MediaType)
                            .Include(p => p.JobType)
                            .Where(p => p.JobTypeID == id).ToList(),

                        JobType = new List<JobTypes>(db.JobTypes).ToList(),

                        MediaType = new List<MediaTypes>(db.MediaTypes).ToList()
                    };

                    return View("Catalog", product);
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);            
                throw;
            

            }
       
        }
     
        
        public ActionResult SortByMedia(CatalogViewModel model)
        {
          
          var id = model.selectMediaTypeId;

            try
            {
                if (id == 0)
                {
                    return RedirectToAction("CatalogList");
                }
                else
                {
                    var product = new CatalogViewModel()
                    {
                        Items = db.ProductCatalog
                            .Include(p => p.MediaType)
                            .Include(p => p.JobType)
                            .Where(p => p.MediaTypeID == id).ToList(),

                        JobType = new List<JobTypes>(db.JobTypes).ToList(),

                        MediaType = new List<MediaTypes>(db.MediaTypes).ToList()

                    };

                    return View("Catalog", product);
                }             
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
      
           
        }
        //*****************************************************

        // GET: ProductCatalog/Create
        public ActionResult Create()
        {
            ViewBag.JobTypeID = new SelectList(db.JobTypes, "JobTypeID", "JobTypeName");
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaTypeName");
            return View();
        }

        // POST: ProductCatalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCatalogID,JobTypeID,MediaTypeID,Price,Description,StockAvailable,SkewNumber,ProductImage")] ProductCatalog productCatalog)
        {
            if (ModelState.IsValid)
            {
                db.ProductCatalog.Add(productCatalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobTypeID = new SelectList(db.JobTypes, "JobTypeID", "JobTypeName", productCatalog.JobTypeID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaTypeName", productCatalog.MediaTypeID);
            return View(productCatalog);
        }

        // GET: ProductCatalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductCatalog productCatalog = db.ProductCatalog.Find(id);
            if (productCatalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobTypeID = new SelectList(db.JobTypes, "JobTypeID", "JobTypeName", productCatalog.JobTypeID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaTypeName", productCatalog.MediaTypeID);
            return View(productCatalog);
        }

        // POST: ProductCatalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCatalogID,JobTypeID,MediaTypeID,Price,Description,StockAvailable,SkewNumber,ProductImage")] ProductCatalog productCatalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productCatalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobTypeID = new SelectList(db.JobTypes, "JobTypeID", "JobTypeName", productCatalog.JobTypeID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaTypeName", productCatalog.MediaTypeID);
            return View(productCatalog);
        }

        // GET: ProductCatalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductCatalog productCatalog = db.ProductCatalog.Find(id);

            if (productCatalog == null)
            {
                return HttpNotFound();
            }
            return View(productCatalog);
        }

        // POST: ProductCatalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCatalog productCatalog = db.ProductCatalog.Find(id);
            db.ProductCatalog.Remove(productCatalog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
