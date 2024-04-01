using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TouristTourGuide.Common.EntityValidationConstans.VoteValueConstans;
namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(VoteValueMax)]
        public int VoteValue { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(TouristTourId))]
        public Guid TouristTourId { get; set; }
        public TouristTour TouristTour { get; set; }
    }
}
