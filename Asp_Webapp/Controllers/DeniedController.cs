using Microsoft.AspNetCore.Mvc;

namespace Asp_Webapp.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
