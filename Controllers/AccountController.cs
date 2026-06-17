using GymManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(model.Username == "admin" && model.Password == "admin123")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }
    }
}
