using Escalada.Models.DataModels;
using Escalada.Persistence.DataModels;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Escalada.Persistence
{
    public static class DependencyInjection
    {
        public static void AddEscaladaDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EscaladaContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICustomerData, EscaladaCustomerData>();
        }
    }
}