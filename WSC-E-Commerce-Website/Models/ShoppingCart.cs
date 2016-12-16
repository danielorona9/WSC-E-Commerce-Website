using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSC_E_Commerce_Website.DAL;

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
            //cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        // TODO: fix item
        public void AddToCart(OrderRequest productOrder)
        {
            var cartItem = db.OrderRequests.SingleOrDefault(c => c.CartId == ShoppingCartId
            && c.ProductCatalogID == productOrder.ProductCatalogID);

           
            if (cartItem == null)
            {
                cartItem = new OrderRequest
                {
                    ProductCatalogID = productOrder.ProductCatalogID,
                    CartId = ShoppingCartId,
                    Quantity = 1
                };
                db.OrderRequests.Add(cartItem);
            }
            else
            {

                cartItem.Quantity++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = db.OrderRequests.Single(cart => cart.CartId == ShoppingCartId && cart.OrderRequestID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    db.OrderRequests.Remove(cartItem);
                }

                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.OrderRequests.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.OrderRequests.Remove(cartItem);
            }

            db.SaveChanges();
        }

        public List<OrderRequest> GetCartItems()
        {
            return db.OrderRequests.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in db.OrderRequests
                where cartItems.CartId == ShoppingCartId
                select (int?) cartItems.Quantity).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.OrderRequests
                where cartItems.CartId == ShoppingCartId
                select (int?) cartItems.Quantity*cartItems.ProductCatalog.Price).Sum();

            return total ?? decimal.Zero;
        }

        //public int CreateOrder()
        //{
            
        //}


    }
}