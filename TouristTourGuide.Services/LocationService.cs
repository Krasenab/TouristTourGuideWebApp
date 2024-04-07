using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.LocationViewModels;

namespace TouristTourGuide.Services
{
    public class LocationService : ILocationService
    {
        private TouristTourGuideDbContext _dbContext;
        public LocationService(TouristTourGuideDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        public void CreateCityCountry(int countryId,string cityName)
        {
            var isCountryExist = _dbContext.Locations.Where(c=>c.Id== countryId).FirstOrDefault();
            if (isCountryExist!=null)
            {
                bool isCountryCityNull = _dbContext.Locations
             .Where(c => c.Id == countryId && c.City == null)
             .Any();
                if (isCountryCityNull==true) 
                {
                    Location ?location = _dbContext.Locations
                        .Where(c=>c.Id==countryId && c.City == null)
                        .FirstOrDefault();

                    location.City = cityName;
                    
                    _dbContext.SaveChanges();

                }
                bool isCountryCityExist = _dbContext.Locations.Where(x=>x.Country == isCountryExist.Country && x.City == cityName).Any();
                if (!isCountryCityExist)
                {
                    Location newLocation = new Location() 
                    {
                        Country = isCountryExist.Country,
                        City = cityName
                    };
                    _dbContext.Locations.Add(newLocation);
                    _dbContext.SaveChanges();   
                }
            }
         
         
        }

        public  List<LocationFormViewModel> GetAllLocations()
        {
           List<LocationFormViewModel> locations = new List<LocationFormViewModel>();

            locations =  _dbContext.Locations.Select(x => new LocationFormViewModel()
            {
                Id = x.Id,
                Country = x.Country
            }).ToList();

            return locations;
        }
    }
}
