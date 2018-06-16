using ISCS.Data;
using ISCS.Data.Infrastucture;
using ISCS.Data.Infrastucture.Interfaces;
using ISCS.Interfaces;
using ISCS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ISCS.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDi(this IServiceCollection services)
        {
            services.AddTransient<DbContext, ApplicationDbContext>();
            services.AddTransient<ITechCardService, TechCardService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
