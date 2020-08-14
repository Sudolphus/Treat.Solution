using System.ComponentModel.DataAnnotations;

namespace Treat.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "This Field is Required")]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required(ErrorMessage ="This Field is Required")]
    public string Password { get; set; }
  }
}