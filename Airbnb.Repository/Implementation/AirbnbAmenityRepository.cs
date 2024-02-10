using Airbnb.Model.Data;
using Airbnb.Model.Models;
using Airbnb.Repository.Interface;

namespace Airbnb.Repository.Implementation
{
    public class AirbnbAmenityRepository : GenericRepository<AirbnbAmenity>, IAirbnbAmenityRepository
    {
        #region Constructor
        public AirbnbAmenityRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        #endregion
    }
}
