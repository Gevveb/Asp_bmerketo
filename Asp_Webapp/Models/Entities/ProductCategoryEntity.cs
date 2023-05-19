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
