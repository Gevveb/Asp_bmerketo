using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Entities;

namespace Asp_Webapp.Helpers.Repositories
{
    public class AddressRepository : Repository<AddressEntity>
    {
        public AddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
