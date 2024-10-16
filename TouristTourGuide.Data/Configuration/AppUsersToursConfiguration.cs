using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nager.Country.CountryInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class AppUsersToursConfiguration : IEntityTypeConfiguration<AppUsersTours>
    {
        public void Configure(EntityTypeBuilder<AppUsersTours> builder)
        {
            builder.HasKey(a => new { a.TouristTourId, a.ApplicationUserId });

            builder.HasOne(a=>a.TouristTour)
                .WithMany(b=>b.AppUsersTours)
                .HasForeignKey(ab=>ab.TouristTourId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.ApplicationUser)
                 .WithMany(b => b.AppUsersTours)
                 .HasForeignKey(c => c.ApplicationUserId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
