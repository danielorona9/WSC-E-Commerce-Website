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
    public class PurchaseOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchaseOrders
        public ActionResult Index()
        {
            var purchaseOrders = 
                db.PurchaseOrders
                .Include(p => p.ApplicationUser)
                .Include(p => p.Employee)
                .Include(p => p.OrderType)
                .Include(p => p.PurchaseOrderStatus);

            return View(purchaseOrders.ToList());
        }

        // GET: PurchaseOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrders purchaseOrders = db.PurchaseOrders.Find(id);

            if (purchaseOrders == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrders);
        }

        // GET: PurchaseOrders/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "OrderTypeName");
            ViewBag.PurchaseOrderStatuesID = new SelectList(db.PurchaseOrderStatuses, "PurchaseOrderStatusID", "StatusName");
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrdersID,PurchaseOrderStatuesID,EmployeeID,OrderTypeID,OrderDate,Total,Deposit,ApplicationUserID")] PurchaseOrders purchaseOrders)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "FirstName", purchaseOrders.ApplicationUserID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", purchaseOrders.EmployeeID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "OrderTypeName", purchaseOrders.OrderTypeID);
            ViewBag.PurchaseOrderStatuesID = new SelectList(db.PurchaseOrderStatuses, "PurchaseOrderStatusID", "StatusName", purchaseOrders.PurchaseOrderStatuesID);
            return View(purchaseOrders);
        }

        // GET: PurchaseOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrders purchaseOrders = db.PurchaseOrders.Find(id);
            if (purchaseOrders == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "FirstName", purchaseOrders.ApplicationUserID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", purchaseOrders.EmployeeID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "OrderTypeName", purchaseOrders.OrderTypeID);
            ViewBag.PurchaseOrderStatuesID = new SelectList(db.PurchaseOrderStatuses, "PurchaseOrderStatusID", "StatusName", purchaseOrders.PurchaseOrderStatuesID);
            return View(purchaseOrders);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrdersID,PurchaseOrderStatuesID,EmployeeID,OrderTypeID,OrderDate,Total,Deposit,ApplicationUserID")] PurchaseOrders purchaseOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "FirstName", purchaseOrders.ApplicationUserID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", purchaseOrders.EmployeeID);
            ViewBag.OrderTypeID = new SelectList(db.OrderTypes, "OrderTypeID", "OrderTypeName", purchaseOrders.OrderTypeID);
            ViewBag.PurchaseOrderStatuesID = new SelectList(db.PurchaseOrderStatuses, "PurchaseOrderStatusID", "StatusName", purchaseOrders.PurchaseOrderStatuesID);
            return View(purchaseOrders);
        }

        // GET: PurchaseOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrders purchaseOrders = db.PurchaseOrders.Find(id);
            if (purchaseOrders == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrders);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrders purchaseOrders = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrders);
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
