using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.AppUserViewModels
{
    public class RegisterFormViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

      
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(20,MinimumLength =2)]
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20,MinimumLength =1)]
        [Display(Name ="Last name")]
        public string LastName { get; set; }
        
        [Display(Name = "Facebook contact")]
        public string FaceBookUrl { get; set; }

        [Display(Name = "Instagram contact")]
        public string InstagramUrl { get; set; }

        [Display(Name = "Twitter contact")]
        public string TwitterUrl { get; set; }

        [Display(Name = "Abaout Me")]
        public string AbaoutMe { get; set; }

    }
}
