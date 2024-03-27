using System.ComponentModel.DataAnnotations;
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

    }
}
