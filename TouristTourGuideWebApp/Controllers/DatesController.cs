using Azure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using TouristTourGuide.Services.Interfaces;
using TouristTourGuide.ViewModels.DatesViewModels;
using TouristTourGuide.ViewModels.TouristTourDatesViewModels;
using Newtonsoft.Json;
using static TouristTourGuide.Common.NotificationMessage;

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
        [HttpPost("checkdate")]
        public async Task<IActionResult> CheckDate([FromBody] ClosedDateCheckInputViewModel model) 
        {
            bool isClosed = await _datesService.IsDateClosed(model.TourId,model.ClosedDate);
           
            if (isClosed)
            {
                var successMessage = new { message = "Get another date for your vacation" };
                return Ok(successMessage);
            }
            else 
            {

                var errorMessage = new { message = "Your date is free" };
                return BadRequest(errorMessage);
              
            }
            
        }
    }
}

