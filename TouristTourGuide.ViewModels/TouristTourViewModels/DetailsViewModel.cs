using Microsoft.AspNetCore.Http;
using TouristTourGuide.ViewModels.AppImageViewModels;

namespace TouristTourGuide.ViewModels.TouristTourViewModels
{
    public class DetailsViewModel
    {
        public string Id { get; set; }
        public string TourName { get; set; }
        public string Duaration { get; set; }
        public decimal PricePerPerson { get; set; }
        public string? Highlights { get; set; }
        public string FullDescription { get; set; }
        public string? NotSuitableFor { get; set; }
        public string MeetingPoint { get; set; }
        public string? MeetingPointMapUrl { get; set; }
        public string? Includes { get; set; }
        public string? WhatToBring { get; set; }
        public string? KnowBeforeYouGo { get; set; }
        public string CreatedOn { get; set; }
        public string LocationCountry { get; set; }
        public string LocationCity { get; set; }
        public string GuideUserId { get; set; }
        public string Category { get; set; }
        public List<AppImagesViewModel> ApplicationImages { get; set; } = new List<AppImagesViewModel>();
    }
}
