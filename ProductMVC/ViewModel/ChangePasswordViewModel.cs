using System.ComponentModel.DataAnnotations;

namespace ProductMVC.ViewModel
{
    public class ChangePasswordViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email Is Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Confirm NewPassword Is Required.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword", ErrorMessage = "Passwords do not match.")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 9)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm NewPassword Is Required.")]
        [DataType(DataType.Password)]

        public string ConfirmNewPassword { get; set; }
    }
}
