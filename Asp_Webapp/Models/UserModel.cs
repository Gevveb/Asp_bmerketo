using Asp_Webapp.Models.Entities;
using Asp_Webapp.Models.Identity;

namespace Asp_Webapp.Models
{
    public class UserModel
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? ProfileImgUrl { get; set; }

        public ICollection<UserAddressEntity> AddressEntities { get; set; } = null!;


        public static implicit operator AppUser(UserModel model)
        {
            return new AppUser
            {
                Id = model.Id,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Addresses = model.AddressEntities
            };
        }
    }
}
