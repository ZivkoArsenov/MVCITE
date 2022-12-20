using Microsoft.AspNetCore.Mvc;
using TestData;

namespace MVCITE.Controllers
{
    public class DataAccessUserController : Controller
    {
        public IActionResult DataAccessUser()
        {
            List<DataAccessUser> listUsers = new List<DataAccessUser>();
            return View("DataAccessUserView", listUsers);
        }
        [HttpPost]
        public JsonResult GetAllData()
        {            
            var testData = TestData.TestData.GetTestData();
            return Json(testData);
        }
    }
}
