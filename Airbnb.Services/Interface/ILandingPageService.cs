using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb.Services.Interface
{
    public interface ILandingPageService
    {
        List<string> GetAirbnbNames();
    }
}
