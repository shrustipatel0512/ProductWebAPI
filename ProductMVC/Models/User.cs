using Microsoft.AspNetCore.Identity;

namespace ProductMVC.Models
{
    public class User :IdentityUser
    {
        public string? FullName { get; set; }
    }
}
