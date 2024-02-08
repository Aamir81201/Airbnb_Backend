using Airbnb.Model.CustomModels;

namespace Airbnb.Model.DTO.Response
{
    public class AirbnbDetailResponseDTO
    {
        public Guid AirbnbId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<string> AirbnbImages { get; set; } = new List<string> { string.Empty };

        public List<AirbnbAmenityModel> AirbnbAmenities { get; set; } = new List<AirbnbAmenityModel>();

        public HostProfileModel HostProfile { get; set; } = new HostProfileModel();

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public decimal Price { get; set; }

        public int Guests { get; set; }

        public int Bedrooms { get; set; }

        public int Beds { get; set; }

        public decimal Bathrooms { get; set; }
    }
}