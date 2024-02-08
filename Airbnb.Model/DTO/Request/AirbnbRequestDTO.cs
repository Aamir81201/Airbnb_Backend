using Airbnb.Model.CustomModels;

namespace Airbnb.Model.DTO.Request
{
    public class AirbnbRequestDTO
    {
        public int CurrentPage { get; set; }
        public int CardsPerPage { get; set; }
        public Location CurrentLocation { get; set; } = new Location();
        public Bounds? Bounds { get; set; }
        public Guid? CategoryId { get; set; }
        public SearchParams? SearchParams { get; set; }
    }
}
