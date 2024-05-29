using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static TouristTourGuide.Common.EntityValidationConstans.TouristTourBookingConstans;

namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class TouristTourBooking
    {
        [Key]
        public Guid Id { get; set; }

        [Required]        
        public DateTime BookedDate { get; set; }

        [Required]
        [Range(countOfPeopleMin,countOfPeopleMax)]
        public int CountOfPeople { get; set; }

        public decimal? TotalPrice { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [DefaultValue(false)]
        public bool isAccepted { get; set; }
        [DefaultValue(false)]
        public bool isRefusced { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(TouristTour))]
        public Guid? TouristTourId { get; set; }
        public virtual TouristTour? TouristTour { get; set; }       
        public string? GuideUserId { get; set; }

    }
}
