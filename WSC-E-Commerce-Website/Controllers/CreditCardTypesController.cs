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
    public class CreditCardTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreditCardTypes
        public ActionResult Index()
        {
            return View(db.CreditCardTypes.ToList());
        }

        // GET: CreditCardTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardType creditCardType = db.CreditCardTypes.Find(id);
            if (creditCardType == null)
            {
                return HttpNotFound();
            }
            return View(creditCardType);
        }

        // GET: CreditCardTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCardTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditCardTypeId,CreditCardTypeName")] CreditCardType creditCardType)
        {
            if (ModelState.IsValid)
            {
                db.CreditCardTypes.Add(creditCardType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creditCardType);
        }

        // GET: CreditCardTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardType creditCardType = db.CreditCardTypes.Find(id);
            if (creditCardType == null)
            {
                return HttpNotFound();
            }
            return View(creditCardType);
        }

        // POST: CreditCardTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditCardTypeId,CreditCardTypeName")] CreditCardType creditCardType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditCardType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creditCardType);
        }

        // GET: CreditCardTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardType creditCardType = db.CreditCardTypes.Find(id);
            if (creditCardType == null)
            {
                return HttpNotFound();
            }
            return View(creditCardType);
        }

        // POST: CreditCardTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCardType creditCardType = db.CreditCardTypes.Find(id);
            db.CreditCardTypes.Remove(creditCardType);
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
