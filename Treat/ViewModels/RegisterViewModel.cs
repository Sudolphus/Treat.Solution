using System.ComponentModel.DataAnnotations;

namespace Treat.ViewModels
{
  public class RegisterViewModel
  {
    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The passwords must match")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }
  }
}