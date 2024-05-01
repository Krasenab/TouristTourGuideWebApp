using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.ViewModels.ApplicationImageViewModels
{
    public class EditTourAlbumViewModel
    {
        public List<AppImagesViewModel> AlbumPicutres { get; set; } = new List<AppImagesViewModel>();
    }
}
