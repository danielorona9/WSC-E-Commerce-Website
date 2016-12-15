using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WSC_E_Commerce_Website.Models;
using WSC_E_Commerce_Website.ViewModels;
using WSC_E_Commerce_Website.DAL;

namespace WSC_E_Commerce_Website.Controllers
{
    [Authorize(Roles = SecurityRoles.Admin)]
    public class UserAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public UserAdminController()
        {
        }

        public UserAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        private ApplicationRoleManager _roleManager;

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { _roleManager = value; }
        }

        //
        //// GET: /UsersAdmin/
        public ActionResult Index()
        {       
            var OProle = (from r in db.Roles where r.Name.Contains(SecurityRoles.OperationsManager) select r).FirstOrDefault();
            var OPusers = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(OProle.Id)).ToList();

            var userVM = OPusers.Select(user => new UserViewModel
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                RoleName = SecurityRoles.OperationsManager
            }).ToList();
            /***************************************************************************************/
            var adminRole = (from r in db.Roles where r.Name.Contains(SecurityRoles.Admin) select r).FirstOrDefault();
            var admins = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(adminRole.Id)).ToList();

            var adminVm = admins.Select(user => new UserViewModel
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                RoleName = SecurityRoles.Admin
            }).ToList();
            /*************************************************************************************/
            var SCrole = (from r in db.Roles where r.Name.Contains(SecurityRoles.SalesClerk) select r).FirstOrDefault();
            var SalesClerk = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(SCrole.Id)).ToList();

            var SaleClerkVM = SalesClerk.Select(user => new UserViewModel
            {
                UserId = user.Id,
                Username = user.UserName,
                Email = user.Email,
                RoleName = SecurityRoles.SalesClerk
            }).ToList();
            /**************************************************************************************/

            var model = new GroupedUserViewModel { OperationsManager = userVM, Admin = adminVm, SaleClerk = SaleClerkVM};
            return View(model);

        }
     
        // GET: /UsersAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);


            return View("Details", user);
        }

        //
        // GET: /UsersAdmin/Create
        public ActionResult Create()
        {
            //Get the list of Roles           
            ViewBag.RoleId = new SelectList(db.Roles.ToList(), "Name", "Name");

            return View();
        }


        //
        // POST: /UsersAdmin/Create
        [HttpPost]
        public async Task<ActionResult> Create(AddRoleToUserViewModel userViewModel, params string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = userViewModel.RegisterViewModel.Email,
                    Email = userViewModel.RegisterViewModel.Email,
                    FirstName = userViewModel.RegisterViewModel.FirstName,
                    LastName = userViewModel.RegisterViewModel.LastName,
                    Address1 = userViewModel.RegisterViewModel.Address1,
                    Address2 = userViewModel.RegisterViewModel.Address2,
                    City = userViewModel.RegisterViewModel.City,
                    State = userViewModel.RegisterViewModel.State,
                    Zip = userViewModel.RegisterViewModel.Zip
                };
                var result = await UserManager.CreateAsync(user, userViewModel.RegisterViewModel.Password);
                //Add User to the selected Roles 
                if (result.Succeeded)
                {
                    var ARresults = await UserManager.AddToRolesAsync(user.Id, selectedRoles);

                     if (!ARresults.Succeeded)
                    {
                        return RedirectToAction("Index", userViewModel);
                    }

                    return RedirectToAction("Index", userViewModel);
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.First());
                    ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
                    return View();
                }
                // return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Name");
            return View();
        }

        //
        // GET: /Users/Edit/1
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userRoles = await UserManager.GetRolesAsync(user.Id);

            return View(new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                RolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            });
        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Email,Id")] EditUserViewModel editUser,
            params string[] selectedRole)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.UserName = editUser.Email;
                user.Email = editUser.Email;

                var userRoles = await UserManager.GetRolesAsync(user.Id);

                selectedRole = selectedRole ?? new string[] {};

                var result =
                    await UserManager.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                result =
                    await
                        UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray<string>());

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        //
        // GET: /Users/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var user = await UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                var result = await UserManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}