using Airbnb.Repository.Interface;
using Airbnb.ViewModels.AirbnbModels;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("GetAirbnbCards")]
        public IActionResult GetAirbnbCards(AirbnbDto airbnbDto)
        {
            try
            {
                return Ok(_unitOfWork.AirbnbRepository.GetAirbnbCards(airbnbDto));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetRoom")]
        public IActionResult GetAirbnbRoom(string airbnbId)
        {
            try
            {
                var a = _unitOfWork.AirbnbRepository.GetAirbnbDetails(airbnbId);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}