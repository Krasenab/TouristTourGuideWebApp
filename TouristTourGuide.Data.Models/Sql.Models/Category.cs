using System.ComponentModel.DataAnnotations;

using static TouristTourGuide.Common.EntityValidationConstans;

namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class Category
    {
        public Category()
        {
           this.TouristTours = new List<TouristTour>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<TouristTour> TouristTours { get; set; }
    }
}
