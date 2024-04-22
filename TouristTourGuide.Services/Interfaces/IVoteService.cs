
namespace TouristTourGuide.Services.Interfaces
{
    public interface IVoteService
    {
        Task AddVoteAsync(string tourId, string applicationUserId, int starValue);
        Task<int> GetUserCurrentVote(string applicationUserId,string tourId);
       Task<double> CalculateRatingAsync(string tourId);
    }
}
