using Asp_Webapp.Helpers.Services;
using Asp_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Asp_Webapp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthenticationService _auth;

        public RegisterController(AuthenticationService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))               
                    ModelState.AddModelError("", "An account with the same email already exists");
                
 

                if(await _auth.RegisterUserAsync(viewModel))
                    return RedirectToAction("index","login");
            }

            return View(viewModel);
        }
    }
}
