using System.ComponentModel.DataAnnotations;
using static TouristTourGuide.Common.EntityValidationConstans.TouristTourBookingConstans;

namespace TouristTourGuide.ViewModels.BookingViewModels
{
    public class CreateBookingViewModel
    {
        public DateTime BookedDate { get; set; }

        [Required]
        public DateTime BookQueryDate { get; set; }

        [Required]
        [Range(countOfPeopleMin, countOfPeopleMax)]
        public int CountOfPeople { get; set; }

        public decimal? TotalPrice { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string ApplicationUserId { get; set; }

        public string TouristTourId { get; set; }
    }
}
