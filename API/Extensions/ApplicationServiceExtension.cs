using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace API.Extensions
{
    public static class ApplicationServiceExtension /* Los metodos de extension son para darle funcionalidad al backend a nuestro proyecto*/
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });
        /* Metodo Extension que permite agregar la unidad de trabajo */
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork , UnitOfWork>();
        }
        public static void ConfigureRatelimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>       /* Se establece el RateLimit basado en la ip*/
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*", /* Para todos (*) los endpoints establezca un perido de 10s donde solo me permita 2 peticiones, esto se hace para no sibrecargar el servidor , para prevenir multiples peticiones automatizadas para no hacer registros maliciosos */
                        Period = "10s",
                        Limit = 2
                    }
                };
            });
        }
    }
}


/* Recordar que los metododos de extension tnenemos que agregarlos a nuestros contenedor de dependencias , es deicr aplicar la inyeccion de dependencias */

