using Asp_Webapp.Models.Identity;
using Asp_WebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Asp_Webapp.Helpers.Services
{
    public class AuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AddressService _addressService;
        private readonly SeedService _seedService;

        public AuthenticationService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, SeedService seedService)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _seedService = seedService;
        }

        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);            
        }

        public async Task<bool> RegisterUserAsync(UserRegisterViewModel viewModel)
        {
            AppUser appUser = viewModel;
            await _seedService.SeedRoles();
            var roleName = "user";

            if(!await _userManager.Users.AnyAsync())
                roleName = "admin";

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);
            if (result.Succeeded) 
            {
                await _userManager.AddToRoleAsync(appUser, roleName);

                var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
                if (addressEntity != null) 
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                }
                return true;
            }
            return false;
        }


        public async Task<bool> LoginAsync(UserLoginViewModel viewModel)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
            if (appUser != null)
            {
               var result = await _signInManager.PasswordSignInAsync(appUser, viewModel.Password, viewModel.RememberMe, false);
                return result.Succeeded;
            }

            return false;
        }
    }
}
