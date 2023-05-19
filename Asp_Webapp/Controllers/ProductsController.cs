using Asp_Webapp.Helpers.Services;
using Asp_Webapp.Models.Entities;
using Asp_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Webapp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;

        public ProductsController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await _categoryService.GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateNewProductVeiwModel viewModel, string[] categories)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.CreateAsync(viewModel))
                {
                    await _productService.AddProductCategoriesAsync(viewModel, categories);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Somthing went wrong");
            }

            ViewBag.Categories = await _categoryService.GetCategoriesAsync(categories);
            return View(viewModel);
        }

        public IActionResult ProductDetailes()
        {
            ViewData["Title"] = "Product";
            return View();
        }

        [HttpGet]
        public async Task<ActionResult<ProductEntity>> ProductDetailes(string Id)
        {
            ViewData["Title"] = "Product";
            var product = await _productService.GetAsync(Id);
            if (product != null)
                return View(product);
            else
                return View();
        }

    }
}
