﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSC_E_Commerce_Website.DAL;
using WSC_E_Commerce_Website.Models;
using Microsoft.AspNet.Identity;
namespace WSC_E_Commerce_Website.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductCatalog  
        public ActionResult Index()
        {      
            ViewBag.Message = "Hompage";
            
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

      
        [Authorize]
        public ActionResult EmployeePortal()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole(SecurityRoles.Admin))
            {             
                return View("EmployeePortal");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole(SecurityRoles.OperationsManager))
            {
                return View("EmployeePortal");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole(SecurityRoles.SalesClerk))
            {
                return View("EmployeePortal");
            }
            else
            {
                return View("Index");
            }

        }

    }
}