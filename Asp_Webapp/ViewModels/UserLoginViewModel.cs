using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp_WebApp.ViewModels;

public class UserLoginViewModel
{
    [DataType(DataType.EmailAddress)]
    [DisplayName("Your E-mail*")]
    public string Email { get; set; } = null!;


    [DataType(DataType.Password)]
    [DisplayName("Your Password*")]
    public string Password { get; set; } = null!;

    [DisplayName("Keep me logged in")]
    public bool RememberMe { get; set; } = true;

    public string ReturnUrl { get; set; } = "/";
}
