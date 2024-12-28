using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TouristTourGuide.Data.Models.Sql.Models;


namespace TouristTourGuide.Data
{
    public class TouristTourGuideDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public TouristTourGuideDbContext(DbContextOptions<TouristTourGuideDbContext> options) : base(options)
        {
            //if(!this.Database.IsRelational()) 
            //{
            //    this.Database.EnsureCreated();
            //}
        }

        public DbSet<TouristTour> TouristsTours { get; set; }
        public DbSet<AppImages> AppImages { get; set; }
        public DbSet<TouristTourBooking> TouristTourBookings { get; set; }
        public DbSet<TouristTourDates> TouristTourDates { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GuideUser> GuideUsers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Comments> Comments { get; set; }

        public DbSet<AppUsersTours> AppUsersTours { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly assembliWithConfig = Assembly.GetAssembly(typeof(TouristTourGuideDbContext)) ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(assembliWithConfig);

            base.OnModelCreating(builder);
        }
    }
}
