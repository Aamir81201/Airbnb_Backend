using Airbnb.Repository.Implementation;
using Airbnb.Repository.Interface;
using Airbnb.Service.Implementation;
using Airbnb.Service.Interface;

namespace Airbnb.Web.Helper
{
    public class ServiceInjector
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IAirbnbRepository, AirbnbRepository>();
            services.AddScoped<IAirbnbSerivce, AirbnbService>();
            services.AddScoped<IAirbnbCategoryRepository, AirbnbCategoryRepository>();
            services.AddScoped<IAirbnbCategoryService, AirbnbCategoryService>();
            services.AddScoped<IAirbnbAmenityRepository, AirbnbAmenityRepository>();
            services.AddScoped<IAirbnbRepository, AirbnbRepository>();

            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
