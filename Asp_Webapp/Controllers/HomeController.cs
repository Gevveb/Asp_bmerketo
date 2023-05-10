using Asp_WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Asp_Webapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new GridCollectionViewModel
                {
                    Title = "Best Collection",
                    Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptops", "Mobile", "Beauty" },
                    GridItems = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel { Id = "1", Title = "Apple watch series", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "2", Title = "Table Lamp", Price = 20, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "3", Title = "laptop thinkpad lenovo", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "4", Title = "Table Lamp", Price = 40, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "5", Title = "Gumshoes black fashion", Price = 50, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "6", Title = "Woman white dress", Price = 60, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "7", Title = "Kettle water boiler", Price = 70, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "8", Title = "Congee cooking rice cooker", Price = 80, ImageUrl = "images/placeholders/270x295.svg" }

                    },
                    LoadMore = true

                },

                TopSellingCollection = new TopSellingGridCollectionViewModel
                {
                    Title = "Top selling products in this week",
                    GridTopSellingItems = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel { Id = "1", Title = "Apple watch series", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "2", Title = "Apple watch series", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "3", Title = "Apple watch series", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "4", Title = "Apple watch series", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "5", Title = "Apple watch series", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "6", Title = "Apple watch series", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                        new GridCollectionItemViewModel { Id = "7", Title = "Apple watch series", Price = 10, ImageUrl = "images/placeholders/270x295.svg" }
                    }
                }
            };
            return View(viewModel);
        }
    }
}
