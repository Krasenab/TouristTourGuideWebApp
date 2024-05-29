
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.ViewModels.BookingViewModels
{
    public class AllBookingViewModel
    {
        public string Id { get; set; }
        public string  TourId { get; set; }
        public string TourName { get; set; }
        public string BookingDate { get; set; }
        public int CountOfPeople { get; set; }
        public decimal PricePerPerson { get; set; }
        public decimal TotalPrice => PricePerPerson * CountOfPeople;
        public string? TourPicutreUniqueName { get; set; }
 
    }
}
