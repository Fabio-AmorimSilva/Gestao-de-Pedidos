namespace GestaoDePedidos.Application;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            services
                .AddUseCases()
                .AddValidators();
            
            return services;
        }

        private IServiceCollection AddUseCases()
        {
            services.AddScoped<UseCaseValidation>();
            
            services.AddScoped<ICriarClienteUseCase, CriarClienteUseCase>();
            services.AddScoped<IObterClientePorIdUseCase, ObterClientePorIdUseCase>();
            services.AddScoped<IObterClientesUseCase, ObterClientesUseCase>();
            services.AddScoped<IDesativarClienteUseCase, DesativarClienteUseCase>();
            
            services.AddScoped<IAtivarProdutoUseCase, AtivarProdutoUseCase>();
            services.AddScoped<IAtualizarEstoqueUseCase, AtualizarEstoqueUseCase>();
            services.AddScoped<IAtualizarProdutoUseCase, AtualizarProdutoUseCase>();
            services.AddScoped<ICadastrarProdutoUseCase, CadastrarProdutoUseCase>();
            services.AddScoped<IDesativarProdutoUseCase, DesativarProdutoUseCase>();
            services.AddScoped<IObterProdutoPorIdUseCase, ObterProdutoPorIdUseCase>();
            services.AddScoped<IObterProdutosUseCase, ObterProdutosUseCase>();

            services.AddScoped<ICriarPedidoUseCase, CriarPedidoUseCase>();
            services.AddScoped<IObterPedidosUseCase, ObterPedidosUseCase>();
            services.AddScoped<IObterPedidoPorIdUseCase, ObterPedidoPorIdUseCase>();
            services.AddScoped<IAlterarStatusPedidoPagoUseCase, AlterarStatusPedidoPagoUseCase>();
            services.AddScoped<IAlterarStatusPedidoEnviadoUseCase, AlterarStatusPedidoEnviadoUseCase>();
            services.AddScoped<IAlterarStatusPedidoParaCanceladoUseCase, AlterarStatusPedidoParaCanceladoUseCase>();
            services.AddScoped<IObterHistoricoStatusPedidoUseCase, ObterHistoricoStatusPedidoUseCase>();

            return services;
        }

        private IServiceCollection AddValidators()
        {
            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
            
            return services;
        }
    }
}