namespace Airbnb.Model.CustomModels
{
    public class SearchParamsModel
    {
        public BoundModel? Bounds { get; set; }

        public GuestModel? Guests { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? CategoryId { get; set; }
    }
}