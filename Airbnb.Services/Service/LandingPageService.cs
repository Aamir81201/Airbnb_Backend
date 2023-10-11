using Airbnb.Repository.Interface;
using Airbnb.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Services.Service
{
    public class LandingPageService: ILandingPageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LandingPageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<string> GetAirbnbNames()
        {
            return _unitOfWork.AirbnbRepository.GetNames();
        }
    }
}
