using Airbnb.DataModels.Data;
using Airbnb.Repository.Interface;
using Airbnb.ViewModels.AirbnbModels;
using Airbnb.ViewModels.CategoryModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Repository.Repository
{
    public class AirbnbRepository : IAirbnbRepository
    {
        private readonly ApplicationDbContext _context;

        public AirbnbRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CategoryModel> GetCategories()
        {
            return _context.AirbnbCategories.Select(c => new CategoryModel()
            {
                Id = c.AirbnbCategoryId,
                Name = c.Name,
                Icon = c.Icon
            }).ToList();
        }

        public List<string> GetNames()
        {
            return _context.Airbnbs.Select(a => a.Name).ToList();
        }

        public AirbnbListModel GetAirbnbCards(AirbnbDto airbnbDto)
        {
            CultureInfo culture = new CultureInfo("en-IN"); // Example: Using US culture

            var airbnbQuery = _context.Airbnbs.AsQueryable();
            int? dayRange = null;
            bool longTitle = false;
            bool showBeds = false;
            if (airbnbDto.SearchParams != null)
            {
                if (airbnbDto.SearchParams.Bounds != null)
                {
                    longTitle = true;
                    airbnbQuery = airbnbQuery.Where(airbnb => airbnb.Latitude <= airbnbDto.SearchParams.Bounds.North
                    && airbnb.Latitude >= airbnbDto.SearchParams.Bounds.South
                    && (airbnbDto.SearchParams.Bounds.East > airbnbDto.SearchParams.Bounds.West ?
                    (airbnb.Longitude <= airbnbDto.SearchParams.Bounds.East && airbnb.Longitude >= airbnbDto.SearchParams.Bounds.West) :
                    (airbnb.Longitude <= airbnbDto.SearchParams.Bounds.East && airbnb.Longitude >= (-180.0)) || (airbnb.Longitude <= 180.0 && airbnb.Longitude >= airbnbDto.SearchParams.Bounds.West))).AsQueryable();
                }
                if (airbnbDto.SearchParams.Guests > 0)
                {
                    showBeds = true;
                    airbnbQuery = airbnbQuery.Where(airbnb => airbnb.Guests >= airbnbDto.SearchParams.Guests).AsQueryable();
                }

                if (airbnbDto.SearchParams.StartDate != null && airbnbDto.SearchParams.EndDate != null)
                {
                    dayRange = (int)(airbnbDto.SearchParams.EndDate.Value.Date - airbnbDto.SearchParams.StartDate.Value.Date).TotalDays;
                    //filter by dates
                }
            }

            if (airbnbDto.Bounds != null)
            {
                airbnbQuery = airbnbQuery.Where(airbnb => airbnb.Latitude <= airbnbDto.Bounds.North
                && airbnb.Latitude >= airbnbDto.Bounds.South
                && (airbnbDto.Bounds.East > airbnbDto.Bounds.West ?
                (airbnb.Longitude <= airbnbDto.Bounds.East && airbnb.Longitude >= airbnbDto.Bounds.West) :
                (airbnb.Longitude <= airbnbDto.Bounds.East && airbnb.Longitude >= (-180.0)) || (airbnb.Longitude <= 180.0 && airbnb.Longitude >= airbnbDto.Bounds.West))
                ).AsQueryable();
            }

            if (airbnbDto.CategoryId != null)
            {
                airbnbQuery = airbnbQuery.Where(airbnb => airbnb.CategoryId.ToString() == airbnbDto.CategoryId);
            }


            var airbnbCards = airbnbQuery.Select(airbnb => new AirbnbCardModel()
            {
                AirbnbId = airbnb.AirbnbId,
                Title = (longTitle ? airbnb.Category.Name + " in " : String.Empty) + airbnb.City + ", " + airbnb.Country,
                AirbnbImages = airbnb.AirbnbMedia.Select(media => media.ImageUrl).ToList(),
                Distance = GetDistance(airbnb.Longitude ?? 0, airbnb.Latitude ?? 0, airbnbDto.CurrentLocation.Lng, airbnbDto.CurrentLocation.Lat),
                Latitude = airbnb.Latitude,
                Longitude = airbnb.Longitude,
                CategoryName = airbnb.Category.Name,
                Price = FormatePrice(airbnb.Price, culture),
                TotalPrice = dayRange != null ? FormatePrice((decimal)(airbnb.Price * dayRange), culture) : null,
                ShortDescription = airbnb.Description,
                Beds = showBeds ? airbnb.Beds : null
            }).AsQueryable();

            AirbnbListModel airbnbs = new AirbnbListModel()
            {
                Count = airbnbCards.Count()
            };

            if (airbnbDto.CurrentPage > 0 && airbnbDto.CardsPerPage > 0)
            {
                int CurrentPage = (int)Math.Round(airbnbDto.CurrentPage);
                int CardsPerPage = (int)Math.Round(airbnbDto.CardsPerPage);
                airbnbCards = airbnbCards.Skip((CurrentPage - 1) * CardsPerPage).Take(CardsPerPage).AsQueryable();
            }

            airbnbs.Cards = airbnbCards.ToList();

            return airbnbs;
        }

        public static double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return Math.Round(6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)))/1000);
        }

        private static string FormatePrice(decimal price, CultureInfo culture)
        {
            return string.Format(culture, "{0:C}", Math.Round(price).ToString("C", culture))?.Replace(".00", "")!;
        }
    }
}
