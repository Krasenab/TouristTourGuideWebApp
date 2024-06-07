using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.ApplicationImageViewModels
{
    public class PageImageViewModel
    {
        public PageImageViewModel()
        {
            this.PageImages = new List<ImagesViewModel>();
        }
        public List<ImagesViewModel> PageImages { get; set; }
    }
}
