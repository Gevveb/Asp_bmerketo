using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Entities;

namespace Asp_Webapp.Helpers.Repositories
{
    public class ContactFormRepo : Repo<ContactFormEntity>
    {
        public ContactFormRepo(DataContext context) : base(context)
        {
        }
    }
}
