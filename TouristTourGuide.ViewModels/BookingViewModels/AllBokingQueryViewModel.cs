namespace TouristTourGuide.ViewModels.BookingViewModels
{
    public class AllBokingQueryViewModel
    {
        public AllBokingQueryViewModel()
        {
            this.AllToursWithBooking = new List<AllBookingViewModel>();     
        }
        
        public string SerchByString { get; set; }
        public int CountOfPeople { get; set; }
        public string TourName { get; set; }
        public string SerchByClosedDate { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TourWithBookingPearPage { get; set; } = 5;
        public int AllBookedTour { get; set; }
        public string? GuideUserId { get; set; }
        public List<AllBookingViewModel> AllToursWithBooking { get; set; }

    }
}
