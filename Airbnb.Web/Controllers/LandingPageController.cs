using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;
using Airbnb.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingPageController : ControllerBase
    {
        private readonly IAirbnbRepository airbnbRepository;

        public LandingPageController(IAirbnbRepository airbnbRepository)
        {
            this.airbnbRepository = airbnbRepository;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                IEnumerable<CategoryResponseDTO> categoryResponseDTO = await airbnbRepository.GetCategories();
                return Ok(categoryResponseDTO);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("GetAirbnbCards")]
        public async Task<IActionResult> GetAirbnbCards(AirbnbRequestDTO airbnbDto)
        {
            try
            {
                AirbnbResponseDTO airbnbResponseDTO = await airbnbRepository.GetAirbnbCards(airbnbDto);
                return Ok(airbnbResponseDTO);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("GetRoom")]
        public async Task<IActionResult> GetAirbnbRoom(Guid airbnbId)
        {
            try
            {
                AirbnbDetailResponseDTO airbnbDetailsDTO = await airbnbRepository.GetAirbnbDetails(airbnbId);
                return Ok(airbnbDetailsDTO);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}