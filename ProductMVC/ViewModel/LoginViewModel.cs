using System.ComponentModel.DataAnnotations;

namespace ProductMVC.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email Is Required.")]
        [EmailAddress]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
