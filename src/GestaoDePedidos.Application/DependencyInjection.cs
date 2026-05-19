namespace GestaoDePedidos.Application;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            services
                .AddServices()
                .AddValidators();
            
            return services;
        }

        private IServiceCollection AddServices()
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            
            
            return services;
        }

        private IServiceCollection AddValidators()
        {
            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
            
            return services;
        }
    }
}