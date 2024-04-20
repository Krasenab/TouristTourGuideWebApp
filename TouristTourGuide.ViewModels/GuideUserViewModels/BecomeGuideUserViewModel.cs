using System.ComponentModel.DataAnnotations;
using TouristTourGuide.Data.Models.Sql.Models;

using static TouristTourGuide.Common.EntityValidationConstans.GuideUserConstants;

namespace TouristTourGuide.ViewModels.GuideUserViewModels
{
    public class BecomeGuideUserViewModel
    {

        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(LegalFirmNameMaxLength)]
        [MinLength(LegalFirmNameMinLength)]
        public string LegalFirmName { get; set; }

        [MaxLength(VATNumberMaxLength)]
        [MinLength(VATNumberMinLength)]
        public string? ValueAddedTaxIdentificationNumber { get; set; }

        [Required]
        [RegularExpression(CRNpattern)]
        public string CompanyRegistrationNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(PhoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(RegisteredAddressMaxLength)]
        [MinLength(RegisteredAddressMinLength)]
        public string RegisteredAddress { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        [MaxLength(AboutMaxLength)]
       
        public string AboutTheActivityProvider { get; set; }
    }
}
