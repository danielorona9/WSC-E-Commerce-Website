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
    public class CreditCardTypeController : Controller
    {
        private EcommerceStoreDB_Context db = new EcommerceStoreDB_Context();

        // GET: CreditCardType
        public ActionResult Index()
        {
            return View(db.CreditCardType.ToList());
        }

        // GET: CreditCardType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardType creditCardType = db.CreditCardType.Find(id);
            if (creditCardType == null)
            {
                return HttpNotFound();
            }
            return View(creditCardType);
        }

        // GET: CreditCardType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCardType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditCardTypeID,CreditCardTypeName")] CreditCardType creditCardType)
        {
            if (ModelState.IsValid)
            {
                db.CreditCardType.Add(creditCardType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creditCardType);
        }

        // GET: CreditCardType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardType creditCardType = db.CreditCardType.Find(id);
            if (creditCardType == null)
            {
                return HttpNotFound();
            }
            return View(creditCardType);
        }

        // POST: CreditCardType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditCardTypeID,CreditCardTypeName")] CreditCardType creditCardType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditCardType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creditCardType);
        }

        // GET: CreditCardType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardType creditCardType = db.CreditCardType.Find(id);
            if (creditCardType == null)
            {
                return HttpNotFound();
            }
            return View(creditCardType);
        }

        // POST: CreditCardType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCardType creditCardType = db.CreditCardType.Find(id);
            db.CreditCardType.Remove(creditCardType);
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
