using Asp_Webapp.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Asp_Webapp.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<UserAddressEntity> Addresses { get; set; } = new HashSet<UserAddressEntity>();

        public static implicit operator UserModel(AppUser model)
        {
            return new UserModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                ProfileImgUrl = model.ImageUrl,
                AddressEntities = model.Addresses
            };
        }

    }
}
