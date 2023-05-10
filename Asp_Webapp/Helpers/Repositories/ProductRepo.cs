using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Entities;

namespace Asp_Webapp.Helpers.Repositories
{
    public class ProductRepo : Repo<ProductEntity>
    {
        public ProductRepo(DataContext context) : base(context)
        {
        }
    }
}
