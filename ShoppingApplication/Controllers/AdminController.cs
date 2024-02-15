using ShoppingApplication.Models;
using System.Web.Mvc;

namespace ShoppingApplication.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminLogin()
        { 
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Admin adminModel)
        {
            if(ModelState.IsValid)
            {
                if(adminModel.Email == "adithi@gmail.com" && adminModel.Password == "xyz@123")
                {
                    return RedirectToAction("AdminShop", "AdminProducts");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email address or password";
                    return View(adminModel);
                }
            }
            return View(adminModel);
        }
    }
}