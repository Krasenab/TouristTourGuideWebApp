using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;

namespace TouristTourGuide.Services
{
    public class VoteService : IVoteService
    {
        private readonly TouristTourGuideDbContext _dbContext;
        public VoteService(TouristTourGuideDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        public async Task AddVoteAsync(string tourId, string applicationUserId, int starValue)
        {
            bool userAlreadyVoted = await _dbContext.Votes.AnyAsync(x => x.TouristTourId.ToString() == tourId 
            && x.ApplicationUserId.ToString() == applicationUserId);

            if (!userAlreadyVoted) 
            {
                Vote v = new Vote()
                {
                    VoteValue = starValue,
                    ApplicationUserId = Guid.Parse(applicationUserId),
                    TouristTourId = Guid.Parse(tourId)
                };

                await _dbContext.Votes.AddAsync(v);

            }
            else
            {
                try
                {
                    Vote getCurrentUserVote = await _dbContext.Votes.
                   Where(v => v.TouristTourId.ToString() == tourId && v.ApplicationUserId.ToString() == applicationUserId)
                   .FirstAsync();

                    getCurrentUserVote.VoteValue = starValue;
                                      
                }
                catch (Exception)
                {

                    throw new ArgumentNullException("Something went wrong with vote");
                }
               
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<double> CalculateRatingAsync(string tourId)
        {
            var votesUsersCount = await _dbContext.Votes.Where(t => t.TouristTourId.ToString() == tourId)
                .Select(s => s.ApplicationUserId.ToString()).CountAsync();
            if (votesUsersCount<1)
            {
                return 0;
            }
            
            double peopleCount = votesUsersCount;
        
            
            
            double rating = _dbContext.Votes.Where(x=>x.TouristTourId.ToString()==tourId).Sum(vS=>vS.VoteValue) / peopleCount;
            double checkResult = rating;
            return rating;

        }

        public Task<int> GetUserCurrentVote(string applicationUserId, string tourId)
        {
            throw new NotImplementedException();
        }
    }
}
