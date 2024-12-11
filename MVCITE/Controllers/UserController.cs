using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCITE.ObjectModel.DataModels;
using MVCITE.ObjectModel.IRepository;

namespace MVCITE.Controllers
{
    public class UserController : Controller
    {
        IUserRepository _userRepository;
        IRoleRepository _roleRepository;

      
        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;

           
        }
        public async Task<IActionResult> User()
        {
            List<User> listUsers = new();
            return View("UserView", listUsers);
        }
       
        public async Task<JsonResult> GetAllData()
        {
            List<User> data = new();
            try
            {
                data = await _userRepository.GetUsersAsync();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
            }
            
            return Json(data);
        }
        
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                List<Role> roles = await _roleRepository.GetRolesAsync();

                var r = roles.Select(r => new SelectListItem
                {
                    Value = r.ID.ToString(),
                    Text = r.Name
                }).ToList();

                ViewData["Roles"] = r;
                User user = await _userRepository.GetUserByIDAsync(Convert.ToInt32(id));
                return View("CreateUser", user);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return View("UserView");
            }
            
        }
       
        public async Task<IActionResult> Add()
        {
            try
            {
                List<Role> roles = await _roleRepository.GetRolesAsync();

                var r = roles.Select(r => new SelectListItem
                {
                    Value = r.ID.ToString(),
                    Text = r.Name
                }).ToList();

                ViewData["Roles"] = r;

                return View("CreateUser", new User());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return View("UserView");
            }
            
        }
       
        public async Task<IActionResult> Remove(string id)
        {
            try
            {
                bool? res = await _userRepository.DeleteUserAsync(Convert.ToInt32(id));
                return Content("pass");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
                return Content(ex.Message);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Save(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (user.ID is 0)
                    {
                        User u = new User {RoleID = user.RoleID, FullName = user.FullName, Email = user.Email,Username = user.Username, Password = user.Password, IsActive = true };
                        await _userRepository.InsertUserAsync(u);
                    }
                    else
                    {
                        await _userRepository.UpdateUserAsync(user);
                    }
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
            }
            return View("UserView");
        }
    }
}
