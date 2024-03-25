

using System.ComponentModel.DataAnnotations;

namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class Dates
    {
        public Dates()
        {
            this.TouristTourDates = new List<TouristTourDates>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TouristTourReserveDate { get; set; }

        public List<TouristTourDates> TouristTourDates { get; set; }
    }
}
