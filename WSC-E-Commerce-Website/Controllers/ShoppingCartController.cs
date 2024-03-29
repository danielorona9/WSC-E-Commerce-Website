﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSC_E_Commerce_Website.DAL;
using WSC_E_Commerce_Website.Models;
using WSC_E_Commerce_Website.ViewModels;

namespace WSC_E_Commerce_Website.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount()
            };
       
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedProductItem = db.ProductCatalog
                .Single(ProductCatalog => ProductCatalog.ProductCatalogID == id);
            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedProductItem);
            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5      
        [HttpPost]
        public JsonResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string ItemName = db.PurchaseOrders
                .Single(item => item.PurchaseOrdersID == id).ProductCatalog.SkewNumber.ToString();

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(ItemName) +
                          " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UpdateCartCounter()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var CartCount = 0;
            {
                CartCount = cart.GetCount();
            }
            return Json(CartCount);
        }

        // GET: /ShoppingCart/CartSummary
        // [ChildActionOnly]
        public ActionResult CartSummary()
        {
           
            var cart = ShoppingCart.GetCart(this.HttpContext);
          
             ViewData["CartCount"] =  cart.GetCount();

            return PartialView("CartSummary");
        }
    }
}