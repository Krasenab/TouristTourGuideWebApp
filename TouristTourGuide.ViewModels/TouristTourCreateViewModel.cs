using System.ComponentModel.DataAnnotations;

using static TouristTourGuide.Common.EntityValidationConstans.TouristToursConstants;
using static TouristTourGuide.Common.EntityValidationConstans.LocationConstans;
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

        [Required]
        [MaxLength(LocationPlaceMaxLength)]
        [MinLength(LocationPlaceMinLength)]
        [Display(Name = "Location Country")]
        public string LocationCountry { get; set; }
        public int CategoryId { get; set; }
       public List<CategoryFormViewModel> Categories { get; set; }
    }
}
