using Newtonsoft.Json;
using TouristTourGuide.Data.DataProcessor.Dto;
using TouristTourGuide.Data.Models.Sql.Models;
using static TouristTourGuide.Common.EntityValidationConstans.LocationConstans;

namespace TouristTourGuide.Data.DataProcessor
{
    public static class Deserializer
    {
        public static List<Location> ImportLocationCountries()
        {
            List<Location> countiesNameList = new List<Location>();
            var json = File.ReadAllText(@"..\TouristTourGuide.Data\Datasets\countries.json");
            var getDataFromJsonFile = JsonConvert.DeserializeObject<ImportCountriesDto[]>(json);

            int locationId = 1;

            foreach (var item in getDataFromJsonFile)
            {

                if (item.Name == null || item.Name.Length < LocationPlaceMinLength || item.Name.Length > LocationPlaceMaxLength) 
                {
                    continue;
                }
                
                
                string currentCountryName = item.Name;
                Location country = new Location()
                {
                    Id = locationId,
                    Country = currentCountryName
                };
                locationId++;
                countiesNameList.Add(country);
            }

            return countiesNameList;

        }
    }
}
