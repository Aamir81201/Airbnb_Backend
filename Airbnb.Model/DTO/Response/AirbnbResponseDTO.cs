using Airbnb.Model.CustomModels;

namespace Airbnb.Model.DTO.Response
{
    public class AirbnbResponseDTO
    {
        public int Count { get; set; }
        public List<AirbnbCardModel> Cards { get; set; } = new List<AirbnbCardModel>();
    }
}
