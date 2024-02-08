using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;

namespace Airbnb.Repository.Interface
{
    public interface IAirbnbRepository
    {
        Task<IEnumerable<string>> GetNames();
        Task<IEnumerable<CategoryResponseDTO>> GetCategories();
        Task<AirbnbResponseDTO> GetAirbnbCards(AirbnbRequestDTO airbnbDto);
        Task<AirbnbDetailResponseDTO> GetAirbnbDetails(Guid airbnbId);
    }
}
