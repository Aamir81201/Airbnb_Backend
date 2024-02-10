using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;

namespace Airbnb.Service.Interface
{
    public interface IAirbnbSerivce : IBaseService<Model.Models.Airbnb>
    {
        Task<IEnumerable<string>> GetNames();

        Task<IEnumerable<CategoryResponseDTO>> GetCategories();

        Task<AirbnbResponseDTO> GetAirbnbCards(AirbnbRequestDTO airbnbRequestDTO);

        Task<AirbnbDetailResponseDTO> GetAirbnbDetails(Guid airbnbId);
    }
}
