namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoPreco;

public class ObterHistoricoPrecoUseCase(IGestaoDePedidosDbContext context) : IObterHistoricoPrecoUseCase
{
    public async Task<Response<PagedResult<ObterHistoricoPrecoUseCaseModel>>> ExecuteAsync(
        ObterHistoricoPrecoRequest request
    )
    {
        var historicos = await context.PedidoHistoricoPreco
            .AsNoTracking()
            .Where(php => php.PedidoId == request.PedidoId)
            .Select(php => new ObterHistoricoPrecoUseCaseModel
            {
                PedidoId = php.PedidoId,
                Preco = php.Preco,
                DataCriacao = php.DataCriacao
            })
            .ToPagedResultAsync(request);

        return new OkResponse<PagedResult<ObterHistoricoPrecoUseCaseModel>>(historicos);
    }
}
