using Asp_Webapp.Models.Entities;

namespace Asp_WebApp.ViewModels
{
    public class ProductInfoViewModel
    {

        public IEnumerable<ProductEntity> Products { get; set; } = null!;

    }
}

//public Guid Id { get; set; }
//public string Title { get; set; } = null!;
//public string ImageUrl { get; set; } = null!;
//public string Category { get; set; } = null!;
//public string? Description { get; set; }
//public decimal Price { get; set; }
//public decimal? PriceDiscount { get; set; } = null!;