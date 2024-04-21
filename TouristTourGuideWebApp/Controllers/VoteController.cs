using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Infrastrucutre;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.VoteViewModels;
using static TouristTourGuide.Infrastrucutre.ClaimPrincipalExtensions;

namespace TouristTourGuideWebApp.Controllers
{
    [Route("api/vote")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private IVoteService _voteService;
        public VoteController(IVoteService voteService)
        {
                _voteService = voteService;
        }
        [HttpPost]
        public async Task<ActionResult<VoteResponseViewModel>> AddVote(VoteInputViewModel voteInputViewModel) 
        {
            string tourId = voteInputViewModel.TourId;           
            string appUserId = ClaimPrincipalExtensions.GetCurrentUserId(this.User);
            int valueOfStarRating = voteInputViewModel.StarValue;

            await _voteService.AddVoteAsync(tourId,appUserId,valueOfStarRating);

            double newRatingValue = await _voteService.GetRatingAsync(tourId);

            VoteResponseViewModel responseValue = new VoteResponseViewModel()
            {
                RatingResultAfretVote = newRatingValue
            };
            return responseValue;
        }
    }
}
