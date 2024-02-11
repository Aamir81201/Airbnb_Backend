using Airbnb.Model.CustomModels;

namespace Airbnb.Model.DTO.Response
{
    public class AirbnbResponseDTO
    {
        public int Count { get; set; }
        public IEnumerable<AirbnbCardModel> Cards { get; set; } = Enumerable.Empty<AirbnbCardModel>();
    }
}
