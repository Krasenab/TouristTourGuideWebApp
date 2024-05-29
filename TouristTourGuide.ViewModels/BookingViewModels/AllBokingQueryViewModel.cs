using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int CurrentPage { get; set; } = 1;
        public int TourWithBookingPearPage { get; set; } = 3;
        public string? GuideUserId { get; set; }
        public List<AllBookingViewModel> AllToursWithBooking { get; set; }
    }
}
