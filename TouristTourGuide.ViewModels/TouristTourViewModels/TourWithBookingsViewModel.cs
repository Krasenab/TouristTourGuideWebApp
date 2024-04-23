using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.BookingViewModels;

namespace TouristTourGuide.ViewModels.TouristTourViewModels
{
    public class TourWithBookingsViewModel
    {
        public TourWithBookingsViewModel()
        {
            this.TourBookings = new List<BookingDetailsViewModel>();
        }
        public string TourName { get; set; }

        public List<BookingDetailsViewModel> TourBookings { get; set; }
    }
}
