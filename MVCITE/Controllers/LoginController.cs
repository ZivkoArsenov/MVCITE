using Microsoft.AspNetCore.Mvc;

namespace MVCITE.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginCheck(string userName, string password)
        {
            return RedirectToAction("DataAccessUser", "DataAccessUser");
        }
    }
}
