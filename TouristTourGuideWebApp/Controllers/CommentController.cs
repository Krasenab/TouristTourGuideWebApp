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

          

            if (model == null || string.IsNullOrEmpty(model.Content) || string.IsNullOrEmpty(model.TourId))
            {
                return Json(new { success = false, message = "Comment or Tour ID is null" });
            }

           
            try
            {
                await _commentsService.Create(model.TourId, model.Content, userId);
                var comment = await _commentsService.GetLatestCommentsAsync(userId);

                return Json(new
                {
                    success = true,
                    message = "Comment posted successfully",
                    data = new
                    {
                       content = comment.Content,
                       appUserName = comment.AppUserName
                    }
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    
    }
}
