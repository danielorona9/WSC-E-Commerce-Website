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
    public class PurchaseOrderStatusController : Controller
    {
        private EcommerceStoreDB_Context db = new EcommerceStoreDB_Context();

        // GET: PurchaseOrderStatus
        public ActionResult Index()
        {
            return View(db.PurchaseOrderStatus.ToList());
        }

        // GET: PurchaseOrderStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderStatus purchaseOrderStatus = db.PurchaseOrderStatus.Find(id);
            if (purchaseOrderStatus == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderStatus);
        }

        // GET: PurchaseOrderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrderStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrderStatusID,StatusName")] PurchaseOrderStatus purchaseOrderStatus)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrderStatus.Add(purchaseOrderStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseOrderStatus);
        }

        // GET: PurchaseOrderStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderStatus purchaseOrderStatus = db.PurchaseOrderStatus.Find(id);
            if (purchaseOrderStatus == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderStatus);
        }

        // POST: PurchaseOrderStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderStatusID,StatusName")] PurchaseOrderStatus purchaseOrderStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrderStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseOrderStatus);
        }

        // GET: PurchaseOrderStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrderStatus purchaseOrderStatus = db.PurchaseOrderStatus.Find(id);
            if (purchaseOrderStatus == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrderStatus);
        }

        // POST: PurchaseOrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrderStatus purchaseOrderStatus = db.PurchaseOrderStatus.Find(id);
            db.PurchaseOrderStatus.Remove(purchaseOrderStatus);
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
