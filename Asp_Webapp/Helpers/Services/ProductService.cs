using Asp_Webapp.Helpers.Repositories;
using Asp_Webapp.Models.Entities;

namespace Asp_Webapp.Helpers.Services
{
    public class ProductService
    {
        private readonly ProductRepo _productRepo;
        private readonly ProductCategoryRepo _productCategoryRepo;
        private readonly CategoryRepo _categoryRepo;

        public ProductService(ProductRepo productRepo, ProductCategoryRepo productCategoryRepo, CategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _productCategoryRepo = productCategoryRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<bool> CreateAsync(ProductEntity entity)
        {
            var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            if (_entity == null)
            {
                _entity = await _productRepo.AddAsync(entity);
                if (_entity != null)
                    return true;
            }

            return false;
        }

        public async Task AddProductCategoriesAsync(ProductEntity entity, string[] categories)
        {
            foreach (var category in categories)
            {
                await _productCategoryRepo.AddAsync(new ProductCategoryEntity
                {
                    ArticleNumber = entity.ArticleNumber,
                    CategoryId = int.Parse(category)
                });
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var products = new List<ProductEntity>();
            var categoriesEntities = new List<CategoryEntity>();

            var items = await _productRepo.GetAllAsync();
            var productCategories = await _productCategoryRepo.GetAllAsync();
            var categories = await _categoryRepo.GetAllAsync();


            foreach (var item in items)
            {
                ProductEntity productEntity = item;
                foreach (var _item in productCategories)
                {
                    foreach (var category in categories)
                    {
                        var categoryEntity = new CategoryEntity
                        {
                            CategoryName = category.CategoryName,
                            Id = category.Id,
                        };
                        categoriesEntities.Add(categoryEntity);
                    }
                }
                products.Add(productEntity);
            }


            return products;
        }

        public async Task<ProductEntity> GetAsync(string id)
        {
            var product = await _productRepo.GetAsync(x => x.ArticleNumber == id);
            return product;
        }
    }
}
