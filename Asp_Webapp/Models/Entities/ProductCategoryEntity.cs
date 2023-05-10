using Asp_Webapp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp_Webapp.Models.Entities
{
    [PrimaryKey(nameof(ArticleNumber), nameof(CategoryId))]
    public class ProductCategoryEntity
    {
        public string ArticleNumber { get; set; } = null!;
        public ProductEntity Product { get; set; } = null!;

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;

    }
}
//public class ProductCategoryEntity
//{
//    public int Id { get; set; }

//    public string CategoryName { get; set; } = null!;

//    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

//}