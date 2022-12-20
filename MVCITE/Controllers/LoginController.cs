using Microsoft.AspNetCore.Mvc;

namespace MVCITE.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginCheck()
        {
            return RedirectToAction("DataAccessUser", "DataAccessUser");
        }
    }
}
