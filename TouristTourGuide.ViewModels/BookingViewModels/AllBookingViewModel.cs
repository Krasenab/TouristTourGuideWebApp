
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.DatesViewModels;

namespace TouristTourGuide.ViewModels.BookingViewModels
{
    public class AllBookingViewModel
    {
        public AllBookingViewModel()
        {
            this.ClosedDates = new List<string>();
        }
        public string Id { get; set; }
        public string  TourId { get; set; }
        public string TourName { get; set; }
        public string BookingDate { get; set; }
        public int CountOfPeople { get; set; }
        public int CountOfBokings { get; set; }
        public decimal PricePerPerson { get; set; }
        public decimal TotalPrice => PricePerPerson * CountOfPeople;
        public string? TourPicutreUniqueName { get; set; }
        
        public List<string> ClosedDates { get; set; }
    }
}
