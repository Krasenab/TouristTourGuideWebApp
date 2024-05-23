using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;

namespace TouristTourGuide.Services
{
    public class DatesService : IDatesService
    {
        private readonly TouristTourGuideDbContext _dbContext;
        public DatesService(TouristTourGuideDbContext dbContext)
        {
                _dbContext = dbContext;
        }
        public async Task CreateTourClosedDate(string tourId, string dates)
        {
            bool isDateExist = await _dbContext.Dates.Where(d => d.ClosedDates.ToString() == dates)
                .AnyAsync();
            int dateId = 0;
            if(!isDateExist) 
            {
                Dates d = new Dates()
                {
                    ClosedDates = DateTime.Parse(dates)
                };
                await _dbContext.Dates.AddAsync(d);
                await _dbContext.SaveChangesAsync();    

                dateId = await _dbContext.Dates.Where(x=>x.Id == d.Id).Select(i=>i.Id)
                    .FirstOrDefaultAsync();                
            }
            else
            {
                dateId  = await _dbContext.Dates.Where(x=>x.ClosedDates.ToString() == dates)
                    .Select(i=>i.Id)
                    .FirstOrDefaultAsync();
            }

            TouristTourDates toD = new TouristTourDates()
            {
                ClosedDatesId = dateId,
                TouristTourId = Guid.Parse(tourId)
            };
           
           await _dbContext.TouristTourDates.AddAsync(toD);
            await _dbContext.SaveChangesAsync();
        }
    }
}
