using Asp_Webapp.Helpers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Webapp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllUsers()
        {
            var users = await _userService.GetAllAsync();
            if (users != null)
            {
                return View(users);
            }else
            {
                ModelState.AddModelError("", "There are no users to see");
                return View();
            }
        }


        public async Task<IActionResult> UpdateUser(string id)
        {
            try
            {
                var currentUser = await _userService.GetAsync(id);
                if (currentUser != null)
                {
                    return View(currentUser);
                }
            }
            catch { }

            return RedirectToAction("allUsers");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(string id, string role)
        {
            try
            {
                var updatedUser = await _userService.UpdateRoleAsync(id, role);
                if (updatedUser != null)
                {
                    return RedirectToAction("allUsers");
                }
            }catch { }

            return View();
        }

    }
}
