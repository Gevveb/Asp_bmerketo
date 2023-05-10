using Asp_Webapp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Asp_WebApp.ViewModels;

public class ContactFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Your name is required")]
    [Display(Name = "Your Name*")]
    [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{1,}$", ErrorMessage ="invalid")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Your email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Your Email*")]
    [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "invalid")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number (optional)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company (optional)")]
    public string? CompanyName { get; set; }

    [Required(ErrorMessage = "Message is required")]
    [Display(Name = "Message*")]
    [RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{1,}$", ErrorMessage = "invalid")]
    public string Message { get; set; } = null!;

    public bool Checkbox { get; set; } = false;

    public static implicit operator ContactFormEntity(ContactFormViewModel model)
    {
        return new ContactFormEntity
        {
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            CompanyName = model.CompanyName,
            Message = model.Message,

        };
    }
}
