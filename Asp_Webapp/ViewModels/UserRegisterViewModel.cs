using Asp_Webapp.Models.Entities;
using Asp_Webapp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp_WebApp.ViewModels
{
    public class UserRegisterViewModel
    {
        [DisplayName("First Name*")]
        [Required(ErrorMessage = "You must provide a First Name")]
        public string FirstName { get; set; } = null!;

        [DisplayName("Last Name*")]
        [Required(ErrorMessage = "You must provide a Last Name")]
        public string LastName { get; set; } = null!;

        [DisplayName("Street Name*")]
        [Required(ErrorMessage = "You must provide a Street Name")]
        public string StreetName { get; set; } = null!;

        [DisplayName("Postal Code*")]
        [Required(ErrorMessage = "You must provide a Postal Code")]
        public string PostalCode { get; set; } = null!;

        [DisplayName("City*")]
        [Required(ErrorMessage = "You must provide a City")]
        public string City { get; set; } = null!;

        [DisplayName("Mobile (optional)")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Company (optional)")]
        public string? CompanyName { get; set; }

        [DisplayName("E-mail*")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "invalid e-mail Address")]
        [Required(ErrorMessage = "You must provide an e-mail Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [DisplayName("Password*")]
        [Required(ErrorMessage = "You must provide a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DisplayName("Confirm Password*")]
        [Required(ErrorMessage = "You must Confirm the Password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "invalid e-mail Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        [DisplayName("Upload Profile Image (optional)")]     
        public IFormFile? ImageUrl { get; set; }

        [DisplayName("I have red and accsepts the Terms and agreements")]
        [Required(ErrorMessage = "You must accsept the Terms and agreements")]
        public bool TermsAndAgreement { get; set; } = false;




        //public static implicit operator IdentityUser(UserRegisterViewModel model)
        //{
        //    return new IdentityUser
        //    {
        //        Email = model.Email,
        //        UserName = model.Email,
        //        PhoneNumber = model.PhoneNumber,
        //    };
        //}

        public static implicit operator AppUser(UserRegisterViewModel viewModel)
        {
            return new AppUser
            {
                UserName = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                CompanyName = viewModel.CompanyName,

            };
        }

        public static implicit operator AddressEntity(UserRegisterViewModel model)
        {
            return new AddressEntity
            {
                StreetName = model.StreetName,
                PostalCode = model.PostalCode,
                City = model.City,
            };
        }

    }
}
