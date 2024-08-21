using Microsoft.AspNetCore.Mvc;

namespace TouristTourGuideWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
