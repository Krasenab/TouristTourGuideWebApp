using System.ComponentModel.DataAnnotations;

using static TouristTourGuide.Common.EntityValidationConstans.TouristToursConstants;
using static TouristTourGuide.Common.EntityValidationConstans.LocationConstans;
using TouristTourGuide.ViewModels.LocationViewModels;
using TouristTourGuide.ViewModels.CategoryVIewModel;
using System.ComponentModel.DataAnnotations.Schema;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.ViewModels.TouristTourViewModels
{
    public class TouristTourCreateViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string TourName { get; set; }

        [Required]
        [MaxLength(DuarationMaxLength)]
        public string Duaration { get; set; }

        
        [Range(PricePerPersonMin, PricePerPersonMax)]
        public decimal PricePerPerson { get; set; }

        [Required]
        public string FullDescription { get; set; }

        [Required]
        public string MeetingPoint { get; set; }
        public string? MeetingPointMapUrl { get; set; }
        public string? StartEndHouers { get; set; }
        public string? Includes { get; set; }
        public string? NotSuitableFor { get; set; }
        public string? NotAllowed { get; set; }
        public string? WhatToBring { get; set; }
        public string? Highlights { get; set; }
        public string? KnowBeforeYouGo { get; set; }
        public string LocationCity { get; set; }
        public string? LocationState { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LocationId { get; set; }        
        public int CategoryId { get; set; }
        public List<CategoryFormViewModel> Categories { get; set; }

        public List<LocationFormViewModel> Locations { get; set; }
    }
}
