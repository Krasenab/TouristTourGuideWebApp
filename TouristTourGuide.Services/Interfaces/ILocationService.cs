using TouristTourGuide.ViewModels.LocationViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ILocationService
    {
        List<LocationFormViewModel> GetAllLocations();
        void CreateCityCountry(int countryId,string cityName);
        Task<LocationFormViewModel> GetLocationCity(string city);
    }
}
