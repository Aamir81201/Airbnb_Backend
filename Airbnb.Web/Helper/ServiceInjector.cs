using Airbnb.Repository.Implementation;
using Airbnb.Repository.Interface;

namespace Airbnb.Web.Helper
{
    public class ServiceInjector
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IAirbnbRepository, AirbnbRepository>();   
            services.AddScoped<IAirbnbCategoryRepository, AirbnbCategoryRepository>();
            services.AddScoped<IAirbnbAmenityRepository, AirbnbAmenityRepository>();
            services.AddScoped<IAirbnbRepository, AirbnbRepository>();
        }
    }
}
