using Asp_Webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Asp_Webapp.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? PriceDiscount { get; set; }

        public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new HashSet<ProductCategoryEntity>();
    }
}


//public class ProductEntity
//{
//    public int Id { get; set; }
//    public string Name { get; set; } = null!;
//    public string ImageUrl { get; set; } = null!;
//    public string? Description { get; set; }
//    public decimal Price { get; set; }
//    public decimal? PriceTotal { get; set; }
//    public int CategoryId { get; set; }
//    public ProductCategoryEntity Category { get; set; } = null!;
//}