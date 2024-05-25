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
            DateTime inputDateTime = DateTime.Parse(dates);
            bool isDateExist = await _dbContext.Dates.Where(d => d.ClosedDates == inputDateTime)
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

        public async Task<bool> IsDateClosed(string tourId,string date)
        {
            DateTime inputDateTime = DateTime.Parse(date);
           
            DateTime dateFromDb = await _dbContext.Dates.Where(x => x.ClosedDates == inputDateTime)
                .Select(x => x.ClosedDates).FirstOrDefaultAsync();

            List<string> allDatesFromDb = await _dbContext.Dates
                .Select(x=>x.ClosedDates.ToShortDateString())
                .ToListAsync();
            
            string stop = "";
            bool isDateExist = await _dbContext.Dates.Where(x=>x.ClosedDates==inputDateTime).AnyAsync();

            if (isDateExist)
            {
                bool isDateClosedForThisTour = await _dbContext.TouristTourDates.Where(td=>td.TouristTourId.ToString()==tourId 
                && td.ClosedDates.ClosedDates==inputDateTime).AnyAsync();
                if (isDateClosedForThisTour)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
               
            }
            else 
            {
                return false;
            }
        }
    }
}
