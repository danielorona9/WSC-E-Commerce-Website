using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSC_E_Commerce_Website.DAL;
using WSC_E_Commerce_Website.ViewModels;
 
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
        public void AddToCart(ProductCatalog productOrder)
        {
            var cartItem = db.PurchaseOrders.SingleOrDefault(c => c.CartID == ShoppingCartId
                                                                 && c.ProductCatalogID == productOrder.ProductCatalogID);


            if (cartItem == null)
            {
                cartItem = new PurchaseOrders
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


        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each             
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderRequest
                {
                    OrderId = order.OrderId,
                    ProductCatalogID = item.ProductCatalogID,
                    Price = item.Price,
                    Quantity = item.Quantity
                };

                // Set the order total of the shopping cart                 
                orderTotal += (item.Quantity*item.Price);

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
                context.Session[CartSessionKey
                    ].
                    ToString();
        }

        // When a user has logged in, migrate their shopping cart to         
        // be associated with their username    
        
           
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.OrderRequests.Where(c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            db.SaveChanges();
        }
       
    } 
   
}
