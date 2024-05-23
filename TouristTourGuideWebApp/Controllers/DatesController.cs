using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.DatesViewModels;
using TouristTourGuide.ViewModels.TouristTourDatesViewModels;

namespace TouristTourGuideWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private IDatesService _datesService;
        public DatesController(IDatesService datesService)
        {
                _datesService = datesService;
        }
        [HttpPost]
        public async Task<IActionResult> AddClosedDateToTour(AddDatesInputViewModel model) 
        {
            try
            {
                await _datesService.CreateTourClosedDate(model.TourId, model.Dates);
                MessageContent message = new MessageContent();
                

                return Ok(message);
            }
            catch (Exception)
            {

                return BadRequest();
            }
         
           
        }
    }
}
