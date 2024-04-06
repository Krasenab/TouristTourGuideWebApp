using TouristTourGuide.ViewModels.LocationViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ILocationService
    {
        List<LocationFormViewModel> GetAllLocations();
    }
}
