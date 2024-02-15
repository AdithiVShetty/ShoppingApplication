using ShoppingApplication.Models;
using System.Linq;
using System.Web.Mvc;

namespace ShoppingApplication.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext dbContext = new AppDbContext();
        public ActionResult Shop()
        {
            var products = dbContext.Products.ToList();
            return View(products);
        }
        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            int userId = GetUserId();
            var existingCartItem = dbContext.CartItems.FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                var newCartItem = new CartItem { UserId = userId, ProductId = productId, Quantity = 1 };
                dbContext.CartItems.Add(newCartItem);
            }
            dbContext.SaveChanges();
            return RedirectToAction("Shop");
        }
        public ActionResult Cart()
        {
            int userId = GetUserId();
            var cartItems = dbContext.CartItems.Where(c => c.UserId == userId).ToList();

            return View(cartItems);
        }
        [HttpPost]
        public ActionResult UpdateCart(int cartItemId, int quantity)
        {
            var cartItem = dbContext.CartItems.Find(cartItemId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Cart");
        }
        public ActionResult Checkout()
        {
            int userId = GetUserId();

            var user = dbContext.Users.Find(userId);
            var cartItems = dbContext.CartItems.Where(c => c.UserId == userId).ToList();
 
            var checkoutModel = new Checkout
            {
                User = user,
                CartItems = cartItems
            };
            return View(checkoutModel);
        }
        [HttpGet]
        public ActionResult PlaceOrder()
        {
            int userId = GetUserId();

            var user = dbContext.Users.Find(userId);
            ViewBag.UserName = user.Name;

            return View();
        }
        //public ActionResult OrderPlaced()
        //{
        //    return View();
        //}
        private int GetUserId()
        {
            if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out int userId))
            {
                return userId;  
            }
            return 0;
        }
    }
}