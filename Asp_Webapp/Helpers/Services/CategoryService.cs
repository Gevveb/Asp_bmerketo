using Asp_Webapp.Helpers.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Webapp.Helpers.Services
{
    public class CategoryService
    {
        private readonly CategoryRepo _categoryRepo;

        public CategoryService(CategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<List<SelectListItem>> GetCategoriesAsync()
        {
            var categories = new List<SelectListItem>();

            foreach (var category in await _categoryRepo.GetAllAsync())
            {
                categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName,
                });
            }
            return categories;
        }

        public async Task<List<SelectListItem>> GetCategoriesAsync(string[] selectedCategories)
        {
            var categories = new List<SelectListItem>();

            foreach (var category in await _categoryRepo.GetAllAsync())
            {
                categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName,
                    Selected = selectedCategories.Contains(category.Id.ToString())
                });
            }
            return categories;
        }
    }
}
