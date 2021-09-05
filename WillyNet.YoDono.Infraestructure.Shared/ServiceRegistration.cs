using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WillyNet.YoDono.Core.Application.Interfaces;
using WillyNet.YoDono.Infraestructure.Shared.Services;
using WillyNet.YoDono.Infraestructure.Shared.Services.Security;

namespace WillyNet.YoDono.Infraestructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddTransient<IAccountService, AccountService>();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                        policy =>
                        {
                            policy
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        }
                    );
            });
        }
    }
}
