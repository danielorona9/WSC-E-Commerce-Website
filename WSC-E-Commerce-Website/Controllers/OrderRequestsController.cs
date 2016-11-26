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
    public class OrderRequestsController : Controller
    {
        private EcommerceStoreDB_Context db = new EcommerceStoreDB_Context();

        // GET: OrderRequests
        public ActionResult Index()
        {
            var orderRequest = db.OrderRequest.Include(o => o.ProductCatalog).Include(o => o.PurchaseOrders);
            return View(orderRequest.ToList());
        }

        // GET: OrderRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRequest orderRequest = db.OrderRequest.Find(id);
            if (orderRequest == null)
            {
                return HttpNotFound();
            }
            return View(orderRequest);
        }

        // GET: OrderRequests/Create
        public ActionResult Create()
        {
            ViewBag.ProductCatalogID = new SelectList(db.ProductCatalog, "ProductCatalogID", "Description");
            ViewBag.PurchaseOrdersID = new SelectList(db.PurchaseOrders, "PurchaseOrdersID", "PurchaseOrdersID");
            return View();
        }

        // POST: OrderRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderRequestID,ProductCatalogID,PurchaseOrdersID,Quantity,Content,Price")] OrderRequest orderRequest)
        {
            if (ModelState.IsValid)
            {
                db.OrderRequest.Add(orderRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCatalogID = new SelectList(db.ProductCatalog, "ProductCatalogID", "Description", orderRequest.ProductCatalogID);
            ViewBag.PurchaseOrdersID = new SelectList(db.PurchaseOrders, "PurchaseOrdersID", "PurchaseOrdersID", orderRequest.PurchaseOrdersID);
            return View(orderRequest);
        }

        // GET: OrderRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRequest orderRequest = db.OrderRequest.Find(id);
            if (orderRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCatalogID = new SelectList(db.ProductCatalog, "ProductCatalogID", "Description", orderRequest.ProductCatalogID);
            ViewBag.PurchaseOrdersID = new SelectList(db.PurchaseOrders, "PurchaseOrdersID", "PurchaseOrdersID", orderRequest.PurchaseOrdersID);
            return View(orderRequest);
        }

        // POST: OrderRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderRequestID,ProductCatalogID,PurchaseOrdersID,Quantity,Content,Price")] OrderRequest orderRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCatalogID = new SelectList(db.ProductCatalog, "ProductCatalogID", "Description", orderRequest.ProductCatalogID);
            ViewBag.PurchaseOrdersID = new SelectList(db.PurchaseOrders, "PurchaseOrdersID", "PurchaseOrdersID", orderRequest.PurchaseOrdersID);
            return View(orderRequest);
        }

        // GET: OrderRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderRequest orderRequest = db.OrderRequest.Find(id);
            if (orderRequest == null)
            {
                return HttpNotFound();
            }
            return View(orderRequest);
        }

        // POST: OrderRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderRequest orderRequest = db.OrderRequest.Find(id);
            db.OrderRequest.Remove(orderRequest);
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
