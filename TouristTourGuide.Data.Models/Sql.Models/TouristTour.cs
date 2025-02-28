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
            this.Comments = new List<Comments>();
            this.Votes = new List<Vote>();
            this.AppUsersTours = new List<AppUsersTours>();
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

        [Required]
        public string MeetingPoint { get; set; }
        public string? MeetingPointMapUrl { get; set; }
        public string? StartEndHouers { get; set; }
        public string? Includes { get; set; }
        public string? NotSuitableFor { get; set; }
        public string? NotAllowed { get; set; }
        public string? WhatToBring { get; set; }
        public string? Highlights { get; set; }

        [MaxLength(KnowBeforeYouGoMax)]
        public string? KnowBeforeYouGo { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(LocationId))]
        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        [ForeignKey(nameof(GuideUserId))]
        public Guid GuideUserId { get; set; }
        public GuideUser GuideUser { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<AppUsersTours> AppUsersTours { get; set; }

        public virtual List<AppImages> TourImages { get; set; }
        public virtual List<TouristTourDates> TouristTourDates { get; set; }
        public virtual List<TouristTourBooking> TouristTourBookings { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public List<Vote> Votes { get; set; }

    }
}