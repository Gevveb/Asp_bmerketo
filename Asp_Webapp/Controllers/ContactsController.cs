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
                    TempData["Message"] = "Thank you for reaching to us! We will come back with an answer for you soon.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Something went wrong.";
                }

                ModelState.AddModelError("", "Something went wrong");
            }
            return View(contactForm);
        }
    }
}
