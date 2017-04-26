using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using WSC_E_Commerce_Website.DAL;
using WSC_E_Commerce_Website.Models;

namespace WSC_E_Commerce_Website.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Checkout


        //GET /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        //[HttpPost]
        //public ActionResult AddressAndPayment(FormCollection values)
        //{
        //    var order = new Order();
        //    TryUpdateModel(order);

        //    try
        //    {
        //        //if (string.Equals(values["PromoCode"], PromoCode,
        //        //    StringComparison.OrdinalIgnoreCase) == false)
        //        //{
        //        //    return View(order);
        //        //}
        //        //else
        //        //{
        //        //    order.Username = User.Identity.Name;
        //        //    order.OrderDate = DateTime.Now;

        //        //    //Save Order
        //        //    db.Orders.Add(order);
        //        //    db.SaveChanges();
        //        //    //Process the order
        //        //    var cart = ShoppingCart.GetCart(this.HttpContext);
        //        //    cart.CreateOrder(order);

        //        //    return RedirectToAction("Complete",
        //        //        new { id = order.OrderId });
        //        //}
        //    }
        //    catch
        //    {
        //        //Invalid - redisplay with errors
        //        return View(order);
        //    }
        //}

    }
}