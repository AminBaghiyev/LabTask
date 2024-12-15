using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.ViewModels;

public class RegisterUserVM
{
    [Length(3, 50)]
    [Display(Prompt = "Enter Firstname")]
    public string FirstName { get; set; }
    [Length(3, 50)]
    [Display(Prompt = "Enter Lastname")]
    public string LastName { get; set; }
    [Display(Prompt = "Enter E-mail")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Length(3, 50)]
    [Display(Prompt = "Enter Username")]
    public string UserName { get; set; }
    [MinLength(4)]
    [Display(Prompt = "Enter Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [MinLength(4)]
    [Display(Prompt = "Enter Password Again")]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
