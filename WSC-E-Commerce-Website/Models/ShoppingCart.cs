using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Async;
using WSC_E_Commerce_Website.DAL;
using WSC_E_Commerce_Website.Models;
using WSC_E_Commerce_Website.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
namespace WSC_E_Commerce_Website.Models
{
    public partial class ShoppingCart
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // variable to store cart session key
        private string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        
        public int AddToCart(ProductCatalog productOrder)
        {
            //gets the id of the current user
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var cartItem = db.PurchaseOrders.SingleOrDefault(c => c.CartID == ShoppingCartId
                                                                  && c.ProductCatalogID == productOrder.ProductCatalogID);


            if (cartItem == null)
            {
                cartItem = new PurchaseOrders
                {
                    ApplicationUserID = user,
                    ProductCatalogID = productOrder.ProductCatalogID,
                    CartID = ShoppingCartId,
                    Count = 1,
                    OrderDate = DateTime.Now,
                    Total = 0,
                    Deposit = 0                 
                };

                db.PurchaseOrders.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

             db.SaveChanges();

            return cartItem.Count;
        }

        //Removes an item from cart
        public int RemoveFromCart(int id)
        {
            var cartItem = db.PurchaseOrders.Single(cart => cart.CartID == ShoppingCartId && cart.PurchaseOrdersID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.PurchaseOrders.Remove(cartItem);
                }

                db.SaveChanges();
            }
            return itemCount;
        }

        //empty cart
        public void EmptyCart()
        {
            var cartItems = db.PurchaseOrders.Where(cart => cart.CartID == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.PurchaseOrders.Remove(cartItem);
            }

            db.SaveChanges();
        }
        //***************************************************
        //get cart items
        public List<PurchaseOrders> GetCartItems()
        {
            return db.PurchaseOrders.Where(cart => cart.CartID == ShoppingCartId).ToList();
        }

        //getCount gets the quanty amount of each item in the cart
        public int GetCount()
        {
            int? count = (from cartItems in db.PurchaseOrders
                where cartItems.CartID == ShoppingCartId
                select (int?) cartItems.Count).Sum();

            return count ?? 0;
        }

        //get total dollar amount in the cart
        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.PurchaseOrders
                where cartItems.CartID == ShoppingCartId
                select (int?) cartItems.Count*cartItems.ProductCatalog.Price).Sum();

            return total ?? decimal.Zero;
        }


        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each             
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderRequest
                {
                    ProductCatalogID = item.ProductCatalogID,
                    OrderId = order.OrderId,
                    Price = item.ProductCatalog.Price,
                    Quantity = item.Count
                };

                // Set the order total of the shopping cart                 
                orderTotal += (item.Count*item.ProductCatalog.Price);

                db.OrderRequests.Add(orderDetail);
            }

            // Set the order's total to the orderTotal count             
            order.Total = orderTotal;

            // Save the order             
            db.SaveChanges();

            // Empty the shopping cart             
            EmptyCart();

            // Return the OrderId as the confirmation number             
            return order.OrderId;
        }

        // We're using HttpContextBase to allow access to cookies.         
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class 


                    Guid tempCartId = Guid.NewGuid();

                    // Send tempCartId back to client as a cookie                     
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return
                context.Session[CartSessionKey]
                                .ToString();
        }

        // When a user has logged in, migrate their shopping cart to         
        // be associated with their username    
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.PurchaseOrders.Where(c => c.CartID == ShoppingCartId);

            foreach (PurchaseOrders item in shoppingCart)
            {
                item.CartID = userName;
            }
            db.SaveChanges();
        }
    }
}