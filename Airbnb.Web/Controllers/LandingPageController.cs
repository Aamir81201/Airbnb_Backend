using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;
using Airbnb.Model.Models;
using Airbnb.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingPageController : ControllerBase
    {
        private readonly IAirbnbSerivce _airbnbService;
        private readonly IAirbnbCategoryService _airbnbCategoryService;
        private readonly IMapper _mapper;

        public LandingPageController(IAirbnbSerivce airbnbService, IAirbnbCategoryService airbnbCategoryService, IMapper mapper)
        {
            _airbnbService = airbnbService;
            _airbnbCategoryService = airbnbCategoryService;
            _mapper = mapper;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                IEnumerable<AirbnbCategory> airbnbCategories = await _airbnbCategoryService.GetAllAsync();
                IEnumerable<CategoryResponseDTO> categoryResponseDTO = _mapper.Map<IEnumerable<CategoryResponseDTO>>(airbnbCategories);
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
                AirbnbResponseDTO airbnbResponseDTO = await _airbnbService.GetAirbnbCards(airbnbDto);
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
                AirbnbDetailResponseDTO airbnbDetailsDTO = await _airbnbService.GetAirbnbDetails(airbnbId);
                return Ok(airbnbDetailsDTO);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}