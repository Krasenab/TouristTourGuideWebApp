using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Events;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;

namespace TouristTourGuideWebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentsService _commentsService;
        public CommentController(ICommentsService comments)
        {
                _commentsService = comments;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentFormViewModel model)
        {
            var userId = ClaimPrincipalExtensions.GetCurrentUserId(this.User);

            //if (model==null|| model.Content==null||model.TourId==null)
            //{
            //    throw new ArgumentNullException("Comment null value");
            //}
            //if (model.TourId==null || model.Content==null ) 
            //{
            //    return Content("Error posting comment");
            //}

            if (model == null || string.IsNullOrEmpty(model.Content) || string.IsNullOrEmpty(model.TourId))
            {
                return Json(new { success = false, message = "Comment or Tour ID is null" });
            }

           
            try
            {
                await _commentsService.Create(model.TourId, model.Content, userId);
                return Json(new { success = true, message = "Comment posted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

          
            
                      
            //return RedirectToAction("Details", "TouristTour", new { id = model.TourId });
        }
    }
}
