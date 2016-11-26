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
    public class BillingController : Controller
    {
        private EcommerceStoreDB_Context db = new EcommerceStoreDB_Context();

        // GET: Billing
        public ActionResult Index()
        {
            var billing = db.Billing.Include(b => b.PurchaseOrders);
            return View(billing.ToList());
        }

        // GET: Billing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // GET: Billing/Create
        public ActionResult Create()
        {
            ViewBag.PurchaseOrdersID = new SelectList(db.PurchaseOrders, "PurchaseOrdersID", "PurchaseOrdersID");
            return View();
        }

        // POST: Billing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillingID,PurchaseOrdersID,BillingDueDate,BillingPaiddueDate,Balance,PaidAmount")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Billing.Add(billing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseOrdersID = new SelectList(db.PurchaseOrders, "PurchaseOrdersID", "PurchaseOrdersID", billing.PurchaseOrdersID);
            return View(billing);
        }

        // GET: Billing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseOrdersID = new SelectList(db.PurchaseOrders, "PurchaseOrdersID", "PurchaseOrdersID", billing.PurchaseOrdersID);
            return View(billing);
        }

        // POST: Billing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillingID,PurchaseOrdersID,BillingDueDate,BillingPaiddueDate,Balance,PaidAmount")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PurchaseOrdersID = new SelectList(db.PurchaseOrders, "PurchaseOrdersID", "PurchaseOrdersID", billing.PurchaseOrdersID);
            return View(billing);
        }

        // GET: Billing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: Billing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Billing billing = db.Billing.Find(id);
            db.Billing.Remove(billing);
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
