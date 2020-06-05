using Escalada.Models.DataModels;
using Escalada.Models.Services;
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
            services.AddScoped<IEventData, EscaladaEventData>();
            services.AddScoped<IInscriptionData, EscaladaInscriptionData>();

            services.AddScoped<InscriptionService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<EventService>();
        }
    }
}