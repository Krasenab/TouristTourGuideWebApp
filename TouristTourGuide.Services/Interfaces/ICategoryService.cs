using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristTourGuide.ViewModels;

namespace TouristTourGuide.Services.Interfaces
{
   public interface ICategoryService
    {
        List<CategoryFormViewModel> GetAllCategories();
    }
}
