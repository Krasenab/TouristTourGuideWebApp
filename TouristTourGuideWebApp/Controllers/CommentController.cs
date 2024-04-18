using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.ViewModels;

namespace TouristTourGuideWebApp.Controllers
{
    public class CommentController : Controller
    {
        public CommentController()
        {
                
        }


        public async Task<IActionResult> CreateComment(CreateCommentFormViewModel viewModel)
        {
            return View();
        }
    }
}
