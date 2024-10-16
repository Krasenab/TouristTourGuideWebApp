using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.AppUserTourViewModels
{
    public class UserTourWishLIstViewModel
    {
        public int Id { get; set; }
        public string? TourName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string TourId { get; set; }
        public string AppUserId { get; set; }

    }
}
