using Asp_Webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Asp_WebApp.ViewModels
{
    public class CreateNewProductVeiwModel
    {

        public string ArticleNumber { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "You need a product Title")]
        [Display(Name = "Product Name*")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [Required(ErrorMessage = "You need a product Image")]
        [Display(Name = "Product Image*")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "The Price is required")]
        [Display(Name = "Price*")]
        public decimal Price { get; set; }
        [Display(Name = "Price after Discount")]
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
    }
}
