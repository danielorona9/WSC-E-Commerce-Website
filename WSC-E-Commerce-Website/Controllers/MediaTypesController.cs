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
    public class MediaTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MediaTypes
        public ActionResult Index()
        {
            return View(db.MediaTypes.ToList());
        }

        // GET: MediaTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaTypes mediaTypes = db.MediaTypes.Find(id);
            if (mediaTypes == null)
            {
                return HttpNotFound();
            }
            return View(mediaTypes);
        }

        // GET: MediaTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MediaTypeID,MediaTypeName")] MediaTypes mediaTypes)
        {
            if (ModelState.IsValid)
            {
                db.MediaTypes.Add(mediaTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mediaTypes);
        }

        // GET: MediaTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaTypes mediaTypes = db.MediaTypes.Find(id);
            if (mediaTypes == null)
            {
                return HttpNotFound();
            }
            return View(mediaTypes);
        }

        // POST: MediaTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MediaTypeID,MediaTypeName")] MediaTypes mediaTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mediaTypes);
        }

        // GET: MediaTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaTypes mediaTypes = db.MediaTypes.Find(id);
            if (mediaTypes == null)
            {
                return HttpNotFound();
            }
            return View(mediaTypes);
        }

        // POST: MediaTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaTypes mediaTypes = db.MediaTypes.Find(id);
            db.MediaTypes.Remove(mediaTypes);
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
