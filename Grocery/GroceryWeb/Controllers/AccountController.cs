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
        public IActionResult Login(string loginViewModel)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
