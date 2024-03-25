

using Microsoft.AspNetCore.Identity;

namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.UserToursBookings = new List<TouristTourBooking>();
            this.AppImages = new List<AppImages>();
        }

        public List<TouristTourBooking> UserToursBookings { get; set; }
        public List<AppImages> AppImages {  get; set; } 
    }
}
