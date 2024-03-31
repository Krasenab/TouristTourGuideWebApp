
using TouristTourGuide.ViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ITourService
    {
        Task CreateTouristTour(TouristTourCreateViewModel viewModel, Guid userGuideId, int locationId);
    }
}
