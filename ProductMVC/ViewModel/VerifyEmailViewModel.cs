using System.ComponentModel.DataAnnotations;

namespace ProductMVC.ViewModel
{
    public class VerifyEmailViewModel

    {

        [EmailAddress]
        [Required(ErrorMessage = "Email Is Required.")]
        public string Email { get; set; }

    }
}
