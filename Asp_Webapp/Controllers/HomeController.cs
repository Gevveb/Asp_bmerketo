using Asp_Webapp.Helpers.Services;
using Asp_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Asp_Webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new GridCollectionViewModel
                {
                    Title = "Best Collection",
                    Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                    GridItems = (await _productService.GetAllAsync()).Take(8),
                    LoadMore = true
                },

                TopSellingCollection = new TopSellingGridCollectionViewModel
                {
                    Title = "Top selling products in this week",
                    GridTopSellingItems = (await _productService.GetAllAsync()).Take(7)
                }
            };
            return View(viewModel);
        }
    }
}
