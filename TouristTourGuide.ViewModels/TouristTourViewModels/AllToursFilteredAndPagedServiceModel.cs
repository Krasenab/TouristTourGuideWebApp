using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristTourGuide.ViewModels.TouristTourViewModels
{
    public class AllToursFilteredAndPagedServiceModel
    {
        public AllToursFilteredAndPagedServiceModel()
        {
            this.Tours = new List<AllViewModel>();
        }
        public int TotalTourCount { get; set; }
        public List<AllViewModel> Tours { get; set; }
    }
}
