using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using WSC_E_Commerce_Website.DAL;

namespace WSC_E_Commerce_Website.Controllers
{
    [Authorize]
    public class RolesAdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
     
        //
        // GET: /RolesAdmin/
        public ActionResult Index()
        {
            var roles = db.Roles;
            return View(roles);
        }

        //
        // GET: /RolesAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = db.Roles.Include(r => r.Users).Single(r => r.Id.Equals(id.ToString()));

            // Get the list of Users in this Role
            // var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            //foreach (var user in UserManager.Users.ToList())
            //{
            //   // if (await UserManager.IsInRoleAsync(user.Id, role.Name))
            //    //{
            //        users.Add(user);
            //    //}
            //}

            //  ViewBag.Users = users;
            //  ViewBag.UserCount = users.Count();
            return View("Details", role);
        }

        //
        // GET: /RolesAdmin/Create
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        //
        // POST: /RolesAdmin/Create
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (ModelState.IsValid)

                db.Roles.Add(Role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /RolesAdmin/Edit/Admin
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        //
        // POST: /RolesAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Id")] IdentityRole roleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /RolesAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /RolesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string deleteUser)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = db.Roles.Find(id);
                db.Roles.Remove(role);
                db.SaveChanges();
                if (role == null)
                {
                    return HttpNotFound();
                }

                return RedirectToAction("Index");
            }
            return View();
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