using System.ComponentModel.DataAnnotations;
using TouristTourGuide.ViewModels.AppImageViewModels;
using TouristTourGuide.ViewModels.DatesViewModels;

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

        [Display(Name = "City")]
        public string LocationCity { get; set; }
        public AppImagesViewModel TourImage { get; set; }
        
    }
}
