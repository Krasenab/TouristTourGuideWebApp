namespace TouristTourGuide.ViewModels.BookingViewModels
{
    public class AllBookingFilteredAndPagedServiceViewModel
    {
        public AllBookingFilteredAndPagedServiceViewModel()
        {
            this.AllBokings = new List<AllBookingViewModel>();
        }
        public int TotalBookingsCount { get; set; }
        public List<AllBookingViewModel> AllBokings { get; set; }
               
    }
}
