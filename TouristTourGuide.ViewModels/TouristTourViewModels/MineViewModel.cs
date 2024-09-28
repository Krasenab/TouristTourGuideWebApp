using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.TouristTourViewModels
{
    public class MineViewModel
    {
        public string TourId { get; set; }
        public string TourName { get; set; }
        public string AppUserId { get; set; }
        public byte[]? TourPicture { get; set; }
    }
}
