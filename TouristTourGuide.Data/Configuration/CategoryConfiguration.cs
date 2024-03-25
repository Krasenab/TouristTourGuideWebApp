using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TouristTourGuide.Data.Models.Sql.Models;

namespace TouristTourGuide.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.CreateCategory());
        }
        private List<Category> CreateCategory()
        {
            List<Category> categories = new List<Category>();

            Category culture = new Category()
            {
                Id = 1,
                Name = "Culture"
            };
            categories.Add(culture);
            Category sports = new Category()
            {
                Id = 2,
                Name = "Sports"
            };
            categories.Add(sports);
            Category nature = new Category()
            {
                Id = 3,
                Name = "Nature"
            };
            categories.Add(nature);
            Category food = new Category()
            {
                Id = 4,
                Name = "Food"
            };
            categories.Add(food);

            Category audioGuide = new Category()
            {
                Id = 5,
                Name = "Audio guides tours"
            };
            categories.Add(audioGuide);

            Category attractions = new Category()
            {
                Id = 6,
                Name = "Attractions"
            };

            categories.Add(attractions);

            Category cityTours = new Category()
            {
                Id = 7,
                Name = "City Tours"
            };

            categories.Add(cityTours);

            Category safari = new Category()
            {
                Id = 8,
                Name ="Safari"
            };

            categories.Add(safari);

            Category religiusAndSpiritualActtivities = new Category()
            {
                Id = 9,
                Name = "Religius and spiritual acttivities"
            };
            categories.Add(religiusAndSpiritualActtivities);

            Category spiritualActivity = new Category()
            {
                Id = 10,
                Name = "Spiritual activity"
            };

            Category historyAndCulture = new Category()
            {
                Id = 11,
                Name = "History and culture"
            };
            categories.Add(historyAndCulture);

           
            return categories;
        }
    }
}
