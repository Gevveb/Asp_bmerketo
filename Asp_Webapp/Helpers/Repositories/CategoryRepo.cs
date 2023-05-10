using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Entities;

namespace Asp_Webapp.Helpers.Repositories
{
    public class CategoryRepo : Repo<CategoryEntity>
    {
        public CategoryRepo(DataContext context) : base(context)
        {
        }
    }
}
