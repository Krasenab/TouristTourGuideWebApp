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
        public int CurrentPage { get; set; }

        public int TourWithBookingPearPage { get; set; }

        public List<AllBookingViewModel> AllToursWithBooking { get; set; }
    }
}
