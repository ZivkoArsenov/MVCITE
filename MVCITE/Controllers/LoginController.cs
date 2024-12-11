using Microsoft.AspNetCore.Mvc;
using MVCITE.ObjectModel.DataModels;
using MVCITE.ObjectModel.DTOs;
using MVCITE.ObjectModel.IRepository;

namespace MVCITE.Controllers
{
    public class LoginController : Controller
    {
        IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;    
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                ViewBag.error = null;

                if (username is null || password is null)
                    throw new CustomException("Username and password are required.");

                User? u = await _userRepository.DoesUserExistsAsync(username, password);

                return RedirectToAction("Index", "Home");
            }
            catch (CustomException ex)
            {
                ViewBag.error = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            try
            {               
              
                if (ModelState.IsValid)
                {
                    user.IsActive = true;
                    bool? res = await _userRepository.InsertUserAsync(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new Exception();
                }
            }            
            catch (Exception)
            {
                return View("Login"); 
            }
            
        }
    }
}
