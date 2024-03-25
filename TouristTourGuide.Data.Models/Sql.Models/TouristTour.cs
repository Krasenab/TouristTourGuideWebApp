﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TouristTourGuide.Common.EntityValidationConstans.TouristToursConstants;
namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class TouristTour
    {
        public TouristTour()
        {
            this.TouristTourDates = new List<TouristTourDates>();
            this.TouristTourBookings = new List<TouristTourBooking>();
            this.TouristTourDates = new List<TouristTourDates>();

        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string TourName { get; set; }

        [Required]
        [MaxLength(DuarationMaxLength)]
        public string Duaration { get; set; }

        [Range(PricePerPersonMin,PricePerPersonMax)]
        public decimal PricePerPerson { get; set; }

        [Required]       
        public string FullDescription { get; set; }

        public string NotSuitableFor { get; set; }

        [Required]
        public string MeetingPoint { get; set; }

        public string MeetingPointMapUrl { get; set; }

        [Required]
        [MaxLength(InformationMaxLenght)]
        public string WhatToBring { get; set; }

        [Required]
        [MaxLength(InformationMaxLenght)]
        public string KnowBeforeYouGo { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Location))]
        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        [ForeignKey(nameof(GuideUserId))]
        public Guid GuideUserId { get; set; }
        public GuideUser GuideUser { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<AppImages> TourImages { get; set; }

        public virtual List<TouristTourDates> TouristTourDates { get; set; }

        public virtual List<TouristTourBooking> TouristTourBookings { get; set; }


    }
}