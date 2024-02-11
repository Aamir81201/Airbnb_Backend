using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;
using Airbnb.Repository.Interface;
using Airbnb.Service.Interface;

namespace Airbnb.Service.Implementation
{
    public class AirbnbService : BaseService<Model.Models.Airbnb>, IAirbnbSerivce
    {
        private readonly IAirbnbRepository _airbnbRepository;
        public AirbnbService(IAirbnbRepository airbnbRepository) : base(airbnbRepository)
        {
            _airbnbRepository = airbnbRepository;
        }

        public async Task<AirbnbResponseDTO> GetAirbnbCards(AirbnbRequestDTO airbnbRequestDTO)
        {
            return await _airbnbRepository.GetAirbnbCards(airbnbRequestDTO);
        }

        public async Task<AirbnbDetailResponseDTO> GetAirbnbDetails(Guid airbnbId)
        {
            return await _airbnbRepository.GetAirbnbDetails(airbnbId);
        }
    }
}
