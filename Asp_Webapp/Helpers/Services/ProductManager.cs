using Asp_Webapp.Helpers.Repositories;
using Asp_Webapp.Models;
using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp_Webapp.Helpers.Services
{
    public class ProductManager
    {
        //private readonly ProductCategoryManager _categoryManager;
        //private readonly ProductRepo _repo;

        //public ProductManager(ProductCategoryManager categoryManager, ProductRepo repo)
        //{
        //    _categoryManager = categoryManager;
        //    _repo = repo;
        //}

        //public async Task AddAsync(ProductAddFormModel form)
        //{
        //    var category = await _categoryManager.GetOrCreateAsync(form.Category);

        //    ProductEntity product = form;
        //    product.CategoryId = category.Id;
            

        //    await _repo.AddAsync(product);
        //}

        //public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        //{
        //    return await _repo.GetAllAsync();
        //}
    }
}
