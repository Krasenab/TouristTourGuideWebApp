

using TouristTourGuide.Data;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels;

namespace TouristTourGuide.Services
{
    public class CategoryService : ICategoryService
    {   
        private TouristTourGuideDbContext _dbContext;
        public CategoryService(TouristTourGuideDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CategoryFormViewModel> GetAllCategories()
        {
            return _dbContext.Categories.Select(x=>new CategoryFormViewModel() 
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
