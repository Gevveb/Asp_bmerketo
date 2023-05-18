using Asp_Webapp.Helpers.Repositories;
using Asp_Webapp.Models;
using Asp_Webapp.Models.Entities;
using Asp_Webapp.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Asp_Webapp.Helpers.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly AddressRepository _addressRepository;
        private readonly UserAddressRepository _repo;

        public UserService(UserRepository userRepo, UserManager<AppUser> userManager, UserAddressRepository repo, AddressRepository addressRepository)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _repo = repo;
            _addressRepository = addressRepository;
        }

        public async Task<UserModel> GetAsync(string id)
        {
            var user = await _userRepo.GetAsync(x => x.Id == id);
            var userAddress = new List<AddressEntity>();
            var addressResults = await _repo.GetAllAsync();
            var addresses = await _addressRepository.GetAllAsync();
            var roles = await _userManager.GetRolesAsync(user);
            if (user != null)
            {
                foreach (var item in addressResults)
                {
                    foreach(var address in addresses)
                    {
                        var addressEntity = new AddressEntity
                        {
                            City = address.City,
                            StreetName = address.StreetName,
                            Id = address.Id,
                            PostalCode = address.PostalCode,
                        };
                        userAddress.Add(addressEntity);
                    }
                }
                if (roles != null)
                {
                    UserModel _user = user;
                    try
                    {
                        _user.Role = roles[0]!;
                    }
                    catch { }
                    return _user;
                }
            }
            return null!;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = new List<UserModel>();
            var _users = await _userRepo.GetAllAsync();
            if (_users != null)
            {
                foreach (var user in _users)
                {
                    UserModel userModel = user;

                    var roleresult = await _userManager.GetRolesAsync(user);
                    foreach (var role in roleresult)
                    {
                        userModel.Role = role;
                    }
                    users.Add(userModel);
                }
                
                return users;
            }
            return null!;
        }

        public async Task<UserModel> UpdateRoleAsync(string id, string updatedrole)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);

                await _userManager.AddToRoleAsync(user, updatedrole);

                await _userManager.UpdateAsync(user);
                return user;
            }
            return null!;
        }
    }
}


