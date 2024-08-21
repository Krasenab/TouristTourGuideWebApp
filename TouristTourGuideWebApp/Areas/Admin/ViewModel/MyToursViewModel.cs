using TouristTourGuide.ViewModels.TouristTourViewModels;

namespace TouristTourGuideWebApp.Areas.Admin.ViewModel
{
    public class MyToursViewModel
    {
       public IEnumerable<AllViewModel> ExistingTours { get; set; }
    }
}
