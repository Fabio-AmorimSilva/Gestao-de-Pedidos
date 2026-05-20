namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoStatusPedido;

public class ObterHistoricoStatusPedidoUseCase(IGestaoDePedidosDbContext context) : IObterHistoricoStatusPedidoUseCase
{
    public async Task<Response<PagedResult<ObterHistoricoStatusPedidoUseCaseModel>>> ExecuteAsync(
        ObterHistoricoStatusPedidoRequest request
    )
    {
        var historicos = await context.PedidoHistoricoStatus
            .AsNoTracking()
            .Where(phs => phs.PedidoId == request.PedidoId)
            .Select(phs => new ObterHistoricoStatusPedidoUseCaseModel
            {
                PedidoId = phs.PedidoId,
                StatusAnterior = phs.StatusAnterior,
                StatusPosterior = phs.StatusPosterior,
                DataAlteracao = phs.DataAlteracao,
                Motivo = phs.Motivo
                    
            })
            .ToPagedResultAsync(request);
        
        return new OkResponse<PagedResult<ObterHistoricoStatusPedidoUseCaseModel>>(historicos);
    }
}