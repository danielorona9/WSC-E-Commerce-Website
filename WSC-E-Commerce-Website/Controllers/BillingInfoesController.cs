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
    public class BillingInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BillingInfoes
        public ActionResult Index()
        {
            var billingInfos = db.BillingInfos.Include(b => b.ApplicationUser).Include(b => b.CreditCardType);
            return View(billingInfos.ToList());
        }

        // GET: BillingInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingInfo billingInfo = db.BillingInfos.Find(id);
            if (billingInfo == null)
            {
                return HttpNotFound();
            }
            return View(billingInfo);
        }

        // GET: BillingInfoes/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.CreditCardTypeID = new SelectList(db.CreditCardTypes, "CreditCardTypeId", "CreditCardTypeName");
            return View();
        }

        // POST: BillingInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillingInfoID,CreditCardTypeID,CreditCardNumber,ExpirationDate,ApplicationUserID")] BillingInfo billingInfo)
        {
            if (ModelState.IsValid)
            {
                db.BillingInfos.Add(billingInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "FirstName", billingInfo.ApplicationUserID);
            ViewBag.CreditCardTypeID = new SelectList(db.CreditCardTypes, "CreditCardTypeId", "CreditCardTypeName", billingInfo.CreditCardTypeID);
            return View(billingInfo);
        }

        // GET: BillingInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingInfo billingInfo = db.BillingInfos.Find(id);
            if (billingInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "FirstName", billingInfo.ApplicationUserID);
            ViewBag.CreditCardTypeID = new SelectList(db.CreditCardTypes, "CreditCardTypeId", "CreditCardTypeName", billingInfo.CreditCardTypeID);
            return View(billingInfo);
        }

        // POST: BillingInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillingInfoID,CreditCardTypeID,CreditCardNumber,ExpirationDate,ApplicationUserID")] BillingInfo billingInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billingInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "FirstName", billingInfo.ApplicationUserID);
            ViewBag.CreditCardTypeID = new SelectList(db.CreditCardTypes, "CreditCardTypeId", "CreditCardTypeName", billingInfo.CreditCardTypeID);
            return View(billingInfo);
        }

        // GET: BillingInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillingInfo billingInfo = db.BillingInfos.Find(id);
            if (billingInfo == null)
            {
                return HttpNotFound();
            }
            return View(billingInfo);
        }

        // POST: BillingInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillingInfo billingInfo = db.BillingInfos.Find(id);
            db.BillingInfos.Remove(billingInfo);
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
