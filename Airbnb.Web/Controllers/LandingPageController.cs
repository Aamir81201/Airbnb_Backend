using Airbnb.Repository.Interface;
using Airbnb.ViewModels.AirbnbModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Airbnb.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingPageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LandingPageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                return Ok(_unitOfWork.AirbnbRepository.GetCategories());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAirbnbCards")]
        public IActionResult GetAirbnbCards(string airbnbDto)
        {
            try
            {
                AirbnbDto airbnbDtoObject = JsonConvert.DeserializeObject<AirbnbDto>(airbnbDto);
                return Ok(_unitOfWork.AirbnbRepository.GetAirbnbCards(airbnbDtoObject));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}