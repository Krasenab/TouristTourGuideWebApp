using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TouristTourGuide.Data.Models.Sql.Models;
using static TouristTourGuide.Data.DataProcessor.Deserializer;
using Nager.Country;
using Nager.Country.Translation;
using TouristTourGuide.Data.DataProcessor.Dto;
using Newtonsoft.Json;

namespace TouristTourGuide.Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(ImportLocationCountries());

        }
       //TODO : refactoring . I can remova SetLocationMethod
        private List<Location> SetLocation()
        {
            var deserilalizerLocationCountries = ImportLocationCountries();
            return deserilalizerLocationCountries;
        }
    }
}
