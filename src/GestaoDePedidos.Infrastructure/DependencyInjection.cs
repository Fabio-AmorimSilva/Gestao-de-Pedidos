using GestaoDePedidos.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            services
                .AddDbContextAndInterceptors(configuration);
            
            return services;
        }

        private IServiceCollection AddDbContextAndInterceptors(IConfiguration configuration)
        {
            services.AddDbContext<GestaoDePedidosDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IGestaoDePedidosDbContext>(provider => provider.GetRequiredService<GestaoDePedidosDbContext>());
            
            return services;
        }
    }
}