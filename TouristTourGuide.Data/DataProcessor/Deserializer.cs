using Newtonsoft.Json;
using TouristTourGuide.Data.DataProcessor.Dto;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.DataProcessor
{
    public static class Deserializer
    {
        public static List<Location> ImportCountryName() 
        {
            List<Location> countiesNameList = new List<Location>();
            var json = File.ReadAllText(@"..\TouristTourGuide.Data\Datasets\countries.json");
            var getDataFromJsonFile = JsonConvert.DeserializeObject<ImportCountriesDto[]>(json);

            int locationId = 1;

            foreach (var item in getDataFromJsonFile)
            {
                
                if (item.Name==null) 
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
