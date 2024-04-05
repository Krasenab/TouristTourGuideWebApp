using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data;
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
