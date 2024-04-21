using System.ComponentModel.DataAnnotations;
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.ViewModels.TouristTourViewModels
{
   public class AllViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Tour title")]
        public string Title { get; set; }

        [Display(Name = "Price per person")]
        public decimal PricePerPerson { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
        public AppImagesViewModel TourImage { get; set; }
    }
}
