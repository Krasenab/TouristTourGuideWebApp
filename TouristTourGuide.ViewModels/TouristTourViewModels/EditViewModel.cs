using System.ComponentModel.DataAnnotations;
using TouristTourGuide.ViewModels.LocationViewModels;

using static TouristTourGuide.Common.EntityValidationConstans.TouristToursConstants;
using static TouristTourGuide.Common.EntityValidationConstans.LocationConstans;
using TouristTourGuide.ViewModels.CategoryVIewModel;

namespace TouristTourGuide.ViewModels.TouristTourViewModels
{
    public class EditViewModel
    {
        public EditViewModel()
        {
           
        }
        public string TourId { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string TourName { get; set; }

        [Required]
        [MaxLength(DuarationMaxLength)]
        [MinLength(DuarationMinLength)]
        public string Duaration { get; set; }

        [Range(PricePerPersonMin, PricePerPersonMax)]
        public decimal PricePerPerson { get; set; }

        [Required]
        [MaxLength(DuarationMaxLength)]
        [MinLength(DuarationMinLength)]
        public string FullDescription { get; set; }

        [MaxLength(NotSuitableForMaxLenght)]
        [MinLength(NotSuitableForMinLenght)]
        public string NotSuitableFor { get; set; }

        [Required]
        public string MeetingPoint { get; set; }
        public string MeetingPointMapUrl { get; set; }

        [Required]
        [MaxLength(WhatToBringMax)]
        public string WhatToBring { get; set; }

        [Required]
        [MaxLength(KnowBeforeYouGoMax)]
        public string KnowBeforeYouGo { get; set; }

        [Required]
        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        [Display(Name = "Location city")]
        public string LocationCity { get; set; }

        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        [Display(Name = "locality for camp etc.")]
        public string LocationVillage { get; set; }
            
        public int CategoryId { get; set; }
        public List<CategoryFormViewModel> ?Categories { get; set; } = new List<CategoryFormViewModel>();
        public int? LocationId { get; set; }
        
        public List<LocationFormViewModel> ?Locations { get; set; } = new List<LocationFormViewModel>();
    }
}
