﻿namespace Airbnb.Model.CustomModels
{
    public class SearchParamsModel
    {
        //public RegionModel? Region { get; set; }
        public string PlaceId { get; set; } = string.Empty;
        public BoundModel? Bounds { get; set; }

        public GuestModel? Guests { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}