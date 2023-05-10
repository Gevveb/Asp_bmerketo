using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Entities;

namespace Asp_Webapp.Helpers.Repositories
{
    public class UserAddressRepository : Repository<UserAddressEntity>
    {
        public UserAddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
