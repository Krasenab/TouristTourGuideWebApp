using System.ComponentModel.DataAnnotations;

using static TouristTourGuide.Common.EntityValidationConstans.TouristToursConstants;
using static TouristTourGuide.Common.EntityValidationConstans.LocationConstans;
using Nager.Country.CountryInfos;
using TouristTourGuide.ViewModels.LocationViewModels;
namespace TouristTourGuide.ViewModels
{
    public class TouristTourCreateViewModel
    {
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

        public int LocationId { get; set; }

        public string GuideUserId { get; set; }
       public List<CategoryFormViewModel> Categories { get; set; }

        public List<LocationFormViewModel> Locations { get; set; }
    }
}
