namespace GestaoDePedidos.Application.UseCases.Pedidos.AlterarStatusPedidoEnviadoUseCase;

public class AlterarStatusPedidoEnviadoUseCase(IGestaoDePedidosDbContext context) : IAlterarStatusPedidoEnviadoUseCase
{
    public async Task<Response> ExecuteAsync(AlterarStatusDto dto)
    {
        var pedido = await context.Pedidos.FirstOrDefaultAsync(p => p.Id == dto.PedidoId);
        
        if(pedido is null)
            return new NotFoundResponse<Pedido>(ErrorMessages.NaoEncontrado<Pedido>());

        var statusAnterior = pedido.Status;
        
        pedido.StatusEnviado();
        
        var historico = new PedidoHistoricoStatus(
            pedidoId: pedido.Id,
            statusAnterior: statusAnterior,
            statusPosterior: pedido.Status,
            motivo: dto.Motivo
        );
        
        await context.PedidoHistoricoStatus.AddAsync(historico);
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}