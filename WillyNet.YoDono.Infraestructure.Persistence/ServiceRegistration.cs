using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WillyNet.YoDono.Core.Application.Interfaces.Repositories;
using WillyNet.YoDono.Core.Domain.Entities;
using WillyNet.YoDono.Infraestructure.Persistence.Contexts;
using WillyNet.YoDono.Infraestructure.Persistence.Repositories;

namespace WillyNet.YoDono.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<YoDonoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            
            #region Identity
            var builder = services.AddIdentityCore<AppUser>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddEntityFrameworkStores<YoDonoDbContext>();
            identityBuilder.AddSignInManager<SignInManager<AppUser>>();
            #endregion


            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<ITipoRepository, TipoRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            #endregion
        }
    }
}
