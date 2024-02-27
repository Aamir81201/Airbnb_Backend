using Airbnb.Model.Common.HelperMethods;
using Airbnb.Model.CustomModels;
using Airbnb.Model.Data;
using Airbnb.Model.DTO.Request;
using Airbnb.Model.DTO.Response;
using Airbnb.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Airbnb.Repository.Implementation
{
    public class AirbnbRepository : GenericRepository<Model.Models.Airbnb>, IAirbnbRepository
    {
        #region Constructor
        public AirbnbRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        #endregion

        #region Methods
        public async Task<AirbnbResponseDTO> GetAirbnbCards(AirbnbRequestDTO airbnbRequestDTO)
        {
            CultureInfo culture = new("en-IN");

            IQueryable<Model.Models.Airbnb> airbnbQuery = _dbContext.Airbnbs.AsQueryable();
            int? dayRange = null;
            bool longTitle = false;
            bool showBeds = false;
            if (airbnbRequestDTO.SearchParams != null)
            {
                if (airbnbRequestDTO.SearchParams.Bounds != null)
                {
                    longTitle = true;
                    airbnbQuery = airbnbQuery.Where(airbnb => airbnb.Latitude <= airbnbRequestDTO.SearchParams.Bounds.North
                    && airbnb.Latitude >= airbnbRequestDTO.SearchParams.Bounds.South
                    && (airbnbRequestDTO.SearchParams.Bounds.East > airbnbRequestDTO.SearchParams.Bounds.West ?
                    airbnb.Longitude <= airbnbRequestDTO.SearchParams.Bounds.East && airbnb.Longitude >= airbnbRequestDTO.SearchParams.Bounds.West :
                    airbnb.Longitude <= airbnbRequestDTO.SearchParams.Bounds.East && airbnb.Longitude >= -180.0 || airbnb.Longitude <= 180.0 && airbnb.Longitude >= airbnbRequestDTO.SearchParams.Bounds.West)).AsQueryable();
                }
                if (airbnbRequestDTO.SearchParams.Guests != null && airbnbRequestDTO.SearchParams.Guests.Adults > 0)
                {
                    showBeds = true;
                    airbnbQuery = airbnbQuery.Where(airbnb => airbnb.Guests >= airbnbRequestDTO.SearchParams.Guests.Adults).AsQueryable();
                }

                if (airbnbRequestDTO.SearchParams.StartDate != null && airbnbRequestDTO.SearchParams.EndDate != null)
                {
                    dayRange = (int)(airbnbRequestDTO.SearchParams.EndDate.Value.Date - airbnbRequestDTO.SearchParams.StartDate.Value.Date).TotalDays;
                }
            }

            if (airbnbRequestDTO.Bounds != null)
            {
                airbnbQuery = airbnbQuery.Where(airbnb => airbnb.Latitude <= airbnbRequestDTO.Bounds.North
                && airbnb.Latitude >= airbnbRequestDTO.Bounds.South
                && (airbnbRequestDTO.Bounds.East > airbnbRequestDTO.Bounds.West ?
                airbnb.Longitude <= airbnbRequestDTO.Bounds.East && airbnb.Longitude >= airbnbRequestDTO.Bounds.West :
                airbnb.Longitude <= airbnbRequestDTO.Bounds.East && airbnb.Longitude >= -180.0 || airbnb.Longitude <= 180.0 && airbnb.Longitude >= airbnbRequestDTO.Bounds.West)
                ).AsQueryable();
            }

            if (airbnbRequestDTO.CategoryId != null)
            {
                //airbnbQuery = airbnbQuery.Where(airbnb => airbnb.CategoryId.ToString() == airbnbDto.CategoryId);
            }

            IQueryable<AirbnbCardModel> airbnbCards = airbnbQuery.Select(airbnb => new AirbnbCardModel()
            {
                AirbnbId = airbnb.AirbnbId,
                Title = (longTitle ? airbnb.Category.Name + " in " : string.Empty) + airbnb.City + ", " + airbnb.Country,
                AirbnbImages = airbnb.AirbnbMedia.Select(media => media.ImageUrl).OrderBy(c => c).ToList(),
                Distance = HelperMethods.GetDistance(airbnb.Longitude ?? 0, airbnb.Latitude ?? 0, airbnbRequestDTO.CurrentLocation.Lng, airbnbRequestDTO.CurrentLocation.Lat),
                Latitude = airbnb.Latitude,
                Longitude = airbnb.Longitude,
                CategoryName = airbnb.Category.Name,
                Price = HelperMethods.FormatePrice(airbnb.Price, culture),
                TotalPrice = dayRange != null ? HelperMethods.FormatePrice((decimal)(airbnb.Price * dayRange), culture) : null,
                ShortDescription = airbnb.Description,
                Beds = showBeds ? airbnb.Beds : null
            }).AsQueryable();

            if (airbnbRequestDTO.CurrentPage > 0 && airbnbRequestDTO.CardsPerPage > 0)
            {
                int CurrentPage = airbnbRequestDTO.CurrentPage;
                int CardsPerPage = airbnbRequestDTO.CardsPerPage;
                airbnbCards = airbnbCards.Skip((CurrentPage - 1) * CardsPerPage).Take(CardsPerPage).AsQueryable();
            }

            AirbnbResponseDTO airbnbResponseDTO = new()
            {
                Count = await airbnbQuery.CountAsync(),
                Cards = await airbnbCards.ToListAsync()
            };

            return airbnbResponseDTO;
        }

        public async Task<AirbnbDetailResponseDTO> GetAirbnbDetail(Guid airbnbId)
        {
            IQueryable<Model.Models.Airbnb> airbnbQuery = _dbContext.Airbnbs.Where(airbnb => airbnb.AirbnbId == airbnbId);
            AirbnbDetailResponseDTO airbnbDetailResponseDTO = await airbnbQuery.Select(airbnb => new AirbnbDetailResponseDTO()
            {
                AirbnbId = airbnb.AirbnbId,
                Name = airbnb.Name,
                Description = airbnb.Description,
                City = airbnb.City,
                Country = airbnb.Country,
                Latitude = airbnb.Latitude,
                Longitude = airbnb.Longitude,
                Bedrooms = airbnb.Bedrooms,
                Guests = airbnb.Guests,
                Beds = airbnb.Beds,
                Bathrooms = airbnb.Bathrooms,
                Price = Math.Round(airbnb.Price, 2),
                AirbnbImages = airbnb.AirbnbMedia.Select(i => i.ImageUrl).OrderBy(i => i).ToList(),
                AirbnbAmenities = airbnb.AirbnbAmenities.Select(a => new AirbnbAmenityModel()
                {
                    Amenity = a.Amenity.Name,
                    Icon = a.Amenity.Icon,
                    AmenityType = a.Amenity.AmenityType.Name
                }).ToList(),
                HostProfile = new HostProfileModel()
                {
                    Name = airbnb.Host.FirstName,
                    Avatar = airbnb.Host.Avatar
                }
            }).FirstOrDefaultAsync() ?? new AirbnbDetailResponseDTO();
            return airbnbDetailResponseDTO;
        }
        #endregion
    }
}