using Asp_Webapp.Helpers.Services;
using Asp_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Webapp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactFormService _contactFormService;

        public ContactsController(ContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Contacts";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel contactForm)
        {
            ViewData["Title"] = "Contacts";

            if (ModelState.IsValid)
            {
                var result = await _contactFormService.CreateAsync(contactForm);
                if (result)
                {
                    TempData["AlertMessage"] = "Success! We have got your message and will come back to you as fast as possible.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Something went wrong");
            }
            return View(contactForm);
        }
    }
}
