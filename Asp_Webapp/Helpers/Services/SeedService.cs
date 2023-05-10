using Asp_Webapp.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Asp_Webapp.Helpers.Services
{
    public class SeedService       
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync("admin"))
                await _roleManager.CreateAsync(new IdentityRole("admin"));

            if (!await _roleManager.RoleExistsAsync("user"))
                await _roleManager.CreateAsync(new IdentityRole("user"));
        }
    }
}
