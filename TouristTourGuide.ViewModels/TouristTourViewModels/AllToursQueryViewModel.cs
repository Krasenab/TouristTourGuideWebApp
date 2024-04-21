using System.ComponentModel.DataAnnotations;
using TouristTourGuide.ViewModels.EnumAppModels;

namespace TouristTourGuide.ViewModels.TouristTourViewModels
{
    public class AllToursQueryViewModel
    {
        public AllToursQueryViewModel()
        {
            this.Tours = new List<AllViewModel>();

            this.Categories = new List<string>();
        }
        public string? Category { get; set; }

        [Display(Name = "Serching by word")]
        public string? SerchByString { get; set; }

        [Display(Name = "Sort tour by")]
        public TourSorting TourSorting { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TourPerPage { get; set; } = 3;
        public int TourTotal { get; set; }
        public List<string> Categories { get; set; }
        public List<AllViewModel> Tours { get; set; }
    }
}
