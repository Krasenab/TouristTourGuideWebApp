using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.BookingViewModels
{
    public class AcceptOrRefuseViewModel
    {
        //целият клас го добаям на : 4/25/2024
        public string TourId { get; set; }
        public string TourName { get; set; }
        public string Rating { get; set; }
        public string GuideUserId { get; set; }
        public int CountOfBooking{ get; set; }
    }
}
