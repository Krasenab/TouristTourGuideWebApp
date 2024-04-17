using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class AppImages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [ForeignKey(nameof(TouristTour))]
        public Guid? TouristTourId { get; set; }
        public TouristTour? TouristTour { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]
        public Guid ApplicationUserId { get; set; } 
        public ApplicationUser ApplicationUser { get; set; }
    }
}
