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
    public class BillingInfoController : Controller
    {
        private EcommerceStoreDB_Context db = new EcommerceStoreDB_Context();

        // GET: BillingInfo
        public ActionResult Index()
        {
            var billingInfo = db.BillingInfo.Include(b => b.CreditCardType).Include(b => b.Customers);
            return View(billingInfo.ToList());
        }

        // GET: BillingInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingInfo billingInfo = db.BillingInfo.Find(id);
            if (billingInfo == null)
            {
                return HttpNotFound();
            }
            return View(billingInfo);
        }

        // GET: BillingInfo/Create
        public ActionResult Create()
        {
            ViewBag.CreditCardTypeID = new SelectList(db.CreditCardType, "CreditCardTypeID", "CreditCardTypeName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            return View();
        }

        // POST: BillingInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillingInfoID,CustomerID,CreditCardTypeID,CreditNumber,ExpirationDate")] BillingInfo billingInfo)
        {
            if (ModelState.IsValid)
            {
                db.BillingInfo.Add(billingInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreditCardTypeID = new SelectList(db.CreditCardType, "CreditCardTypeID", "CreditCardTypeName", billingInfo.CreditCardTypeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", billingInfo.CustomerID);
            return View(billingInfo);
        }

        // GET: BillingInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingInfo billingInfo = db.BillingInfo.Find(id);
            if (billingInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreditCardTypeID = new SelectList(db.CreditCardType, "CreditCardTypeID", "CreditCardTypeName", billingInfo.CreditCardTypeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", billingInfo.CustomerID);
            return View(billingInfo);
        }

        // POST: BillingInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillingInfoID,CustomerID,CreditCardTypeID,CreditNumber,ExpirationDate")] BillingInfo billingInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billingInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreditCardTypeID = new SelectList(db.CreditCardType, "CreditCardTypeID", "CreditCardTypeName", billingInfo.CreditCardTypeID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", billingInfo.CustomerID);
            return View(billingInfo);
        }

        // GET: BillingInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingInfo billingInfo = db.BillingInfo.Find(id);
            if (billingInfo == null)
            {
                return HttpNotFound();
            }
            return View(billingInfo);
        }

        // POST: BillingInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillingInfo billingInfo = db.BillingInfo.Find(id);
            db.BillingInfo.Remove(billingInfo);
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
