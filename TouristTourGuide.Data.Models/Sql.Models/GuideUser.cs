using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static TouristTourGuide.Common.EntityValidationConstans.GuideUserConstants;

namespace TouristTourGuide.Data.Models.Sql.Models
{
    public class GuideUser
    {
        public GuideUser()
        {
            this.MyTours = new List<TouristTour>();      
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(LegalFirmNameMaxLength)]
        public string LegalFirmName { get; set; }

        [MaxLength(VATNumberMaxLength)]
        public string ValueAddedTaxIdentificationNumber { get; set; }

        [Required]
        [MaxLength(CRNLenghtMax)]
        [RegularExpression(CRNpattern)]
        public string CompanyRegistrationNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(RegisteredAddressMaxLength)]
        public string RegisteredAddress { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [MaxLength(AboutMaxLength)]
        public string AboutTheActivityProvider { get; set; }

        public virtual List<TouristTour> MyTours { get; set; }
    }
}
