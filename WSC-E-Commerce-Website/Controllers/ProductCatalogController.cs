using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WSC_E_Commerce_Website.DAL;
using WSC_E_Commerce_Website.Models;

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
        public ActionResult Create([Bind(Include = "ProductCatalogID,JobTypeID,MediaTypeID,Price,Description,StockAvailable,ProductImage")] ProductCatalog productCatalog)
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
        public ActionResult Edit([Bind(Include = "ProductCatalogID,JobTypeID,MediaTypeID,Price,Description,StockAvailable,ProductImage")] ProductCatalog productCatalog)
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
