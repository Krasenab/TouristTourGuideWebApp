using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static TouristTourGuide.Common.EntityValidationConstans.AppUsersConstans;
namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.UserToursBookings = new List<TouristTourBooking>();
            this.AppImages = new List<AppImages>();
        }
      

        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; }
        
        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; }

        public List<TouristTourBooking> UserToursBookings { get; set; }
        public List<AppImages> AppImages {  get; set; } 
    }
}
