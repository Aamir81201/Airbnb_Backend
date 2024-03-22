using Airbnb.Model.CustomModels;

namespace Airbnb.Model.DTO.Request
{
    public class AirbnbRequestDTO
    {
        public PaginationModel PageInfo { get; set; } = new PaginationModel();
        public LocationModel CurrentLocation { get; set; } = new LocationModel();
        public SearchParamsModel SearchParams { get; set; } = new SearchParamsModel();
    }
}
