using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.ViewModels.AppUserViewModels
{
     public class AppUserProfileViewModel
    {
        public AppUserProfileViewModel()
        {
                
        }

        public string UserName { get; set; }

        public string LastName { get; set; }

        public AppImagesViewModel AppUserPicute { get; set; }
    }
}
