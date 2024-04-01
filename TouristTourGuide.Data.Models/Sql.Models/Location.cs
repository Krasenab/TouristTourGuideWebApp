using System.ComponentModel.DataAnnotations;

using static TouristTourGuide.Common.EntityValidationConstans.LocationConstans;

namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class Location
    {
        public Location()
        {
            this.TouristTours = new List<TouristTour>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(LocationPlaceMaxLength)]
        public string Country { get; set; }

        [Required]
        [MaxLength(LocationPlaceMaxLength)]
        public string City  { get; set; }

        [MaxLength(LocationPlaceMaxLength)]
        public string? Village { get; set; }

        public virtual List<TouristTour> TouristTours { get; set; }
    }
}
