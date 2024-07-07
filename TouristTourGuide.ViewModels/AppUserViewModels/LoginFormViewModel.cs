
using System.ComponentModel.DataAnnotations;

namespace TouristTourGuide.ViewModels.AppUserViewModels
{
    public class LoginFormViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string? ReturnUrl { get; set; }
    }
}
