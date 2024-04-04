using System.ComponentModel.DataAnnotations;

namespace TouristTourGuide.Data.DataProcessor.Dto
{
    public class ImportCountriesDto
    {
        [Required]
        public string Name { get; set; } 
    }
}
