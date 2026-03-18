using System.ComponentModel.DataAnnotations;

namespace ProductMVC.ViewModel
{
    public class RegisterViewModel 
    {
        [Required(ErrorMessage = "Name Is Required.")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email Is Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 9)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Is Required.")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
    }
}
