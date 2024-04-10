using TouristTourGuide.ViewModels.LocationViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ILocationService
    {
        List<LocationFormViewModel> GetAllLocations();
        void CreateCityCountry(int countryId,string cityName);

        Task<string> GetTourCity(string tourLocationId);

        bool isCountryCityExist(int? locationId, string city);

        Task<LocationFormViewModel> LocationByTourId(string tourId);
    }
}
