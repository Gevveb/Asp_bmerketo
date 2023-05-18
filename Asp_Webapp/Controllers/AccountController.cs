using Asp_Webapp.Helpers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Asp_Webapp.Controllers
{
    
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id != null) 
            {
                var user = await _userService.GetAsync(id);
                if (user != null)
                    return View(user);
            }
            return View();
        }
    }
}
