using ShoppingApplication.Models;
using System.Linq;
using System.Web.Mvc;

namespace ShoppingApplication.Controllers
{
    public class AdminProductsController : Controller
    {
        // GET: AdminProducts
        //private static List<Product> productList = new List<Product>
        //{
        //    new Product { Id = 101, Name = "HP Laptop", Price = 70000 },
        //    new Product { Id = 102, Name = "Dell Laptop", Price = 65000 },
        //    new Product { Id = 103, Name = "Macbook", Price = 150000 },
        //    new Product { Id = 104, Name = "Iphone", Price = 120000 },
        //    new Product { Id = 105, Name = "OnePlus Mobile", Price = 60000 },
        //    new Product { Id = 106, Name = "Printer", Price = 50000},
        //};

        public ActionResult AdminShop()
        {
            using (var context = new AppDbContext())
            {
                var productList = context.Products.ToList();
                return View(productList);
            }
        }
        public ActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new AppDbContext())
                {
                    context.Products.Add(model);
                    context.SaveChanges();
                }
                return RedirectToAction("AdminShop");
            }
            return View(model);
        }
        //public ActionResult RemoveProduct()
        //{
        //    using (var context = new AppDbContext())
        //    {
        //        var productList = context.Products.ToList();
        //        return View(productList);
        //    }
        //}
        [HttpPost]
        public ActionResult RemoveProduct(int productId)
        {
            using (var context = new AppDbContext())
            {
                var productToRemove = context.Products.Find(productId);

                if (productToRemove != null)
                {
                    context.Products.Remove(productToRemove);
                    context.SaveChanges();
                }

                return RedirectToAction("AdminShop");
            }
        }
    }
}