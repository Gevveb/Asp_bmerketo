using Asp_Webapp.Models;
using Asp_Webapp.Models.Entities;

namespace Asp_WebApp.ViewModels
{
    public class CreateNewProductVeiwModel
    {

        public string ArticleNumber { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? PriceDiscount { get; set; }

        public static implicit operator ProductEntity(CreateNewProductVeiwModel viewModel)
        {
            return new ProductEntity
            {
                ArticleNumber = viewModel.ArticleNumber,
                Name = viewModel.Name,
                Description = viewModel.Description,
                ImageUrl = viewModel.ImageUrl,
                Price = viewModel.Price,
                PriceDiscount = viewModel.PriceDiscount,
            };
        }

        //public ProductAddFormModel Form { get; set; } = new ProductAddFormModel();

        //public IEnumerable<ProductCategoryModel> ProductCategories { get; set; } = new List<ProductCategoryModel>();



    }
}
