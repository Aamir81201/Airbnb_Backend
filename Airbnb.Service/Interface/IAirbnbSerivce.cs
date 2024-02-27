using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;

namespace Airbnb.Service.Interface
{
    public interface IAirbnbSerivce : IBaseService<Model.Models.Airbnb>
    {
        Task<AirbnbResponseDTO> GetAirbnbCards(AirbnbRequestDTO airbnbRequestDTO);

        Task<AirbnbDetailResponseDTO> GetAirbnbDetail(Guid airbnbId);
    }
}
