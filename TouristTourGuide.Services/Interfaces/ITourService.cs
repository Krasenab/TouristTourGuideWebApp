
using TouristTourGuide.ViewModels;
using TouristTourGuide.ViewModels.TouristTourViewModels;

namespace TouristTourGuide.Services.Interfaces
{
    public interface ITourService
    {
        void CreateTouristTour(TouristTourCreateViewModel viewModel,string guidUserId);

        Task<EditViewModel> GetTourForEdit(string tourId);
    }
}
