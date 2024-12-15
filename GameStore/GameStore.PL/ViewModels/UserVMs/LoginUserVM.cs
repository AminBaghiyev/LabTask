using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.ViewModels;

public class LoginUserVM
{
    [Length(3, 50)]
    [Display(Prompt = "Enter Username")]
    public string UserName { get; set; }
    [MinLength(4)]
    [DataType(DataType.Password)]
    [Display(Prompt = "Enter Password")]
    public string Password { get; set; }
    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}
