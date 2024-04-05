using TouristTourGuide.ViewModels.LocationViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    interface ILocationService
    {
        List<LocationFormViewModel> GetAllLocations();
    }
}
