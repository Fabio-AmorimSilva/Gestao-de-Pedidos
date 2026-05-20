namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoStatusPedido;

public class ObterHistoricoStatusPedidoUseCase(IGestaoDePedidosDbContext context) : IObterHistoricoStatusPedidoUseCase
{
    public async Task<Response<IEnumerable<ObterHistoricoStatusPedidoUseCaseModel>>> ExecuteAsync(Guid pedidoId)
    {
        var historicos = await context.PedidoHistoricoStatus
            .AsNoTracking()
            .Where(phs => phs.PedidoId == pedidoId)
            .Select(phs => new ObterHistoricoStatusPedidoUseCaseModel
            {
                StatusAnterior = phs.StatusAnterior,
                StatusPosterior = phs.StatusPosterior,
                DataAlteracao = phs.DataAlteracao,
                Motivo = phs.Motivo
            }).ToListAsync();
        
        return new OkResponse<IEnumerable<ObterHistoricoStatusPedidoUseCaseModel>>(historicos);
    }
}