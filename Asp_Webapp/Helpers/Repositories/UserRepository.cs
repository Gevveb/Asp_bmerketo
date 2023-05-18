using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Identity;

namespace Asp_Webapp.Helpers.Repositories
{
    public class UserRepository : Repository<AppUser>
    {
        public UserRepository(IdentityContext context) : base(context)
        {
        }
    }
}
