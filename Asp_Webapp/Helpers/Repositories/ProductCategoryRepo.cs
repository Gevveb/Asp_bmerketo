using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Entities;

namespace Asp_Webapp.Helpers.Repositories
{
    public class ProductCategoryRepo : Repo<ProductCategoryEntity>
    {
        public ProductCategoryRepo(DataContext context) : base(context)
        {
        }
    }
}
