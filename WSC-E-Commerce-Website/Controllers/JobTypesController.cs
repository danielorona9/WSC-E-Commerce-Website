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
    public class JobTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobTypes
        public ActionResult Index()
        {
            return View(db.JobTypes.ToList());
        }

        // GET: JobTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTypes jobTypes = db.JobTypes.Find(id);
            if (jobTypes == null)
            {
                return HttpNotFound();
            }
            return View(jobTypes);
        }

        // GET: JobTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobTypeID,JobTypeName")] JobTypes jobTypes)
        {
            if (ModelState.IsValid)
            {
                db.JobTypes.Add(jobTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobTypes);
        }

        // GET: JobTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTypes jobTypes = db.JobTypes.Find(id);
            if (jobTypes == null)
            {
                return HttpNotFound();
            }
            return View(jobTypes);
        }

        // POST: JobTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobTypeID,JobTypeName")] JobTypes jobTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobTypes);
        }

        // GET: JobTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTypes jobTypes = db.JobTypes.Find(id);
            if (jobTypes == null)
            {
                return HttpNotFound();
            }
            return View(jobTypes);
        }

        // POST: JobTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobTypes jobTypes = db.JobTypes.Find(id);
            db.JobTypes.Remove(jobTypes);
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
