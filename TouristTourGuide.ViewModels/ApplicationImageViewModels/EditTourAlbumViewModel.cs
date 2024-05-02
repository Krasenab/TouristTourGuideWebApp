using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.ViewModels.ApplicationImageViewModels.EditTourAlbumViewModel
{
    public class EditTourAlbumViewModel
    {
        public string TourId { get; set; }
      public  List<AppImagesViewModel> TourImages { get; set; } = new List<AppImagesViewModel>();
    }
}
