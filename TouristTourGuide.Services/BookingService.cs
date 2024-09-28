using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data;
using TouristTourGuide.Data.Models.Sql.Models;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.BookingViewModels;

namespace TouristTourGuide.Services
{
    public class BookingService : IBookingService
    {
        private readonly TouristTourGuideDbContext _db;

        public BookingService(TouristTourGuideDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task AcceptBooking(string bookingId)
        {
            var b = await _db.TouristTourBookings.Where(x => x.Id.ToString() == bookingId).FirstOrDefaultAsync();
            //add if(b!=null) on 4/25/2024 
            if (b != null)
            {
                if (b.isAccepted == true)
                {
                    b.isAccepted = false;
                }
                else
                {
                    b.isAccepted = true;
                }
            }
            bool check = b.isAccepted;

            await _db.SaveChangesAsync();
        }

        public async Task<List<BookingDetailsViewModel>> BookingsDetails(string tourId)
        {
            var bookings = await _db.TouristTourBookings.Where(t => t.TouristTourId.ToString() == tourId)
                .Select(x => new BookingDetailsViewModel()
                {
                    Id = x.Id.ToString(),
                    TourName = x.TouristTour.TourName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    CountOfPeople = x.CountOfPeople,
                    BookingDate = x.BookedDate.ToString("yyyy/MM/dd"),
                    // и това забравих да добавя преди 4/25/2024 тоест не го добвих на 4/23/2024
                    isAccepted = x.isAccepted,
                    AppUserId = x.ApplicationUser.FirstName + x.ApplicationUser.LastName

                }).ToListAsync();
            return bookings;
        }

        public async Task CreateBooking(CreateBookingViewModel viewModel)
        {
            TouristTourBooking b = new TouristTourBooking()
            {
                CountOfPeople = viewModel.CountOfPeople,
                ApplicationUserId = Guid.Parse(viewModel.ApplicationUserId),
                TouristTourId = Guid.Parse(viewModel.TouristTourId),
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                GuideUserId = viewModel.TourOwnerId,
                BookedDate = viewModel.BookedDate
                
            };

            await _db.TouristTourBookings.AddAsync(b);
            await _db.SaveChangesAsync();
        }



        //добавям този метод на 4/25/2024 
        public async Task<List<AcceptOrRefuseViewModel>> GetAcceptedTourBookings(string userGuideId)
        {
            var tB = await _db.TouristTourBookings.Where(x => x.TouristTour.GuideUserId.ToString() == userGuideId)
                .Select(x => new AcceptOrRefuseViewModel()
                {
                    TourName = x.TouristTour.TourName,
                }).ToListAsync();

            return tB;
        }

        public async Task<AllBookingFilteredAndPagedServiceViewModel> GetAll(AllBokingQueryViewModel queryViewModel)
        {
            IQueryable<TouristTourBooking> query = _db.TouristTourBookings
                 .Include(b => b.TouristTour)
                 .ThenInclude(t => t.TouristTourDates)
                 .ThenInclude(td => td.ClosedDates)
                .Where(gU => gU.GuideUserId == queryViewModel.GuideUserId)
                .AsQueryable();

            if (!string.IsNullOrEmpty(queryViewModel.SerchByString))
            {
                //generate wide card 
                string wildCard = $"%{queryViewModel.SerchByString.ToLower()}%";

                query = query.Where(qb => EF.Functions.Like(qb.TouristTour.TourName, wildCard)||
                                    EF.Functions.Like(qb.BookedDate.ToString(),wildCard)||
                                    EF.Functions.Like(qb.CountOfPeople.ToString(),wildCard));
            }
            if (!string.IsNullOrEmpty(queryViewModel.SerchByClosedDate)) 
            {
                DateTime closedDates;
                if (DateTime.TryParse(queryViewModel.SerchByClosedDate,out closedDates)) 
                {
                    query = query.Where(qb => qb.TouristTour.TouristTourDates.Any(td => td.ClosedDates.ClosedDates == closedDates));
                }

            }

            List<AllBookingViewModel> allBokings = await query.Skip((queryViewModel.CurrentPage - 1) * queryViewModel.TourWithBookingPearPage).Take(queryViewModel.TourWithBookingPearPage)
                .Select(x => new AllBookingViewModel()
                {
                    Id = x.Id.ToString(),
                    BookingDate = x.BookedDate.ToString(),
                    CountOfPeople = x.CountOfPeople,
                    TourId = x.TouristTourId.ToString(),
                    TourName = x.TouristTour.TourName,
                    TourPicutreUniqueName = x.TouristTour.TourImages.Select(n => n.UniqueFileName).FirstOrDefault(),

                }).ToListAsync();
            int totalBokings = allBokings.Count;

            return new AllBookingFilteredAndPagedServiceViewModel
            {
                AllBokings = allBokings,
                TotalBookingsCount = totalBokings
            };
        }

        public async Task RefuseBooking(string bookingId)
        {
            var b = await _db.TouristTourBookings.Where(x => x.Id.ToString() == bookingId)
                .FirstOrDefaultAsync();
            if (b == null)
            {
                throw new NullReferenceException("Empty bookings");
            }
            b.isAccepted = false;
        }
    }
}
