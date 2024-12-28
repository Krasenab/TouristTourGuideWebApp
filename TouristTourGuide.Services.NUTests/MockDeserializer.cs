using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data;
using TouristTourGuide.Data.DataProcessor.Dto;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Services.NUTests
{
    public static class MockDeserializer
    {
        
        public static void AddLocation(TouristTourGuideDbContext ttgDbContext) 
        {
          //  List<Location> l = new List<Location>();
            var json = File.ReadAllText(@"..\TouristTourGuide.Data\Datasets\countries.json");
          
            var getDataFromJsonFile = JsonConvert.DeserializeObject<ImportCountriesDto[]>(json);

            int ids = 1;
            foreach (var location in getDataFromJsonFile)
            {
                Location loc = new Location()
                { Id = ids,
                    Country = location.Name
                };
                ids++;
                ttgDbContext.Locations.Add(loc);
            }

            ttgDbContext.SaveChanges();
        }

    }
}
