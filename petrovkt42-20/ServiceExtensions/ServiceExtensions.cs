using petrovkt42_20.Interfaces.DegreeInterfaces;
using petrovkt42_20.Interfaces.PrepodInterfaces;

namespace petrovkt42_20.ServiceInterfaces
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPrepodService, PrepodService>();
            services.AddScoped<IDegreesService, DegreeService>();

            return services;
        }
    }
}
