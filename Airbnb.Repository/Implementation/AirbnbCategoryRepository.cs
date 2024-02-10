using Airbnb.Model.Data;
using Airbnb.Model.Models;
using Airbnb.Repository.Interface;

namespace Airbnb.Repository.Implementation
{
    public class AirbnbCategoryRepository : GenericRepository<AirbnbCategory>, IAirbnbCategoryRepository
    {
        #region Constructor
        public AirbnbCategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { }
        #endregion
    }
}
