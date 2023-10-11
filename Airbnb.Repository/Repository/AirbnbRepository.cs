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

        public List<AirbnbCardModel> GetAirbnbCards(AirbnbDto airbnbDto)
        {
            CultureInfo culture = new CultureInfo("en-IN"); // Example: Using US culture

            var cards = _context.Airbnbs.Where(airbnb => airbnbDto.Bounds == null || (airbnb.Latitude <= airbnbDto.Bounds.North && airbnb.Latitude >= airbnbDto.Bounds.South && airbnb.Longitude <= airbnbDto.Bounds.East && airbnb.Longitude >= airbnbDto.Bounds.West)).Select(airbnb => new AirbnbCardModel()
            {
                AirbnbId = airbnb.AirbnbId,
                City = airbnb.City,
                Country = airbnb.Country,
                AirbnbImages = airbnb.AirbnbMedia.Select(media => media.ImageUrl).ToList(),
                Distance = Math.Round(GetDistance(airbnb.Longitude ?? 0, airbnb.Latitude ?? 0, airbnbDto.CurrentLocation.Lat, airbnbDto.CurrentLocation.Lng) / 1000),
                Latitude = airbnb.Latitude,
                Longitude = airbnb.Longitude,
                CategoryName = airbnb.Category.Name,
                Price = string.Format(culture, "{0:C}", Math.Round(airbnb.Price).ToString("C", culture)).Replace(".00", "")
            }).ToList();

            return cards;
        }

        public static double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
