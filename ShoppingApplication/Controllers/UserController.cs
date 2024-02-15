using ShoppingApplication.Models;
using System.Linq;
using System.Web.Mvc;

namespace ShoppingApplication.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext dbContext = new AppDbContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User userModel)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.Email == userModel.Email && u.Password == userModel.Password);
            if (user != null)
            {
                Session["UserId"] = user.Id;
                return RedirectToAction("Shop", "Products");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email address or password";
                return View(userModel);
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User userModel)
        {
            if (ModelState.IsValid)
            {
                dbContext.Users.Add(userModel);
                dbContext.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(userModel);
        }
    }
}