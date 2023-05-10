using Asp_Webapp.Models.Entities;
using Asp_Webapp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp_Webapp.Models.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> AspNetAddresses { get; set; }
        public DbSet<UserAddressEntity> AspNetUserAddresses { get; set; }
    }
}
