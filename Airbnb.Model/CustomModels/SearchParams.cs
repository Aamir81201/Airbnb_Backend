namespace Airbnb.Model.CustomModels
{
    public class SearchParams
    {
        public RegionModel? Region { get; set; }
        public BoundModel? Bounds { get; set; }
        public GuestModel? Guests { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class RegionModel
    {
        public string Input { get; set; } = null!;
        public string PlaceId { get; set; } = null!;
    }

}