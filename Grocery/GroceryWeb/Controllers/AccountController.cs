using GroceryBOL;
using Microsoft.AspNetCore.Mvc;

namespace GroceryWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if(loginViewModel.Email == "admin@hackbal.com" && loginViewModel.Password == "T")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
