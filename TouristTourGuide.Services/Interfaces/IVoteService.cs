
namespace TouristTourGuide.Services.Interfaces
{
    public interface IVoteService
    {
        
        Task<int> CountVoteByTourIdAsync(string tourId);
  
        Task AddVoteAsync(string tourId, string applicationUserId, int starValue);
        Task<int> GetUserCurrentVote(string applicationUserId,string tourId);
       Task<double> CalculateRatingAsync(string tourId);

        //add 4/27/2024
        void DeleteAllTourVote(string tourId);  
    }
}
