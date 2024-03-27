using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TouristTourGuide.Common.EntityValidationConstans.Comments;
namespace TouristTourGuide.Data.Models.Sql.Models
{

    public class Comments
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(contentMaxLength)]
        public string Content { get; set; }

        [ForeignKey(nameof(TouristTourId))]
        public Guid TouristTourId { get; set; }

        public virtual TouristTour TouristTour { get; set; }
    }
}
