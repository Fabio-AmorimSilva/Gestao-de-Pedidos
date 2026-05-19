using Microsoft.Extensions.DependencyInjection;

namespace GestaoDePedidos.Application;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            services.AddServices();
            
            return services;
        }

        private IServiceCollection AddServices()
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            
            
            return services;
        }
    }
}