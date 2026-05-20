namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoStatusPedido;

public interface IObterHistoricoStatusPedidoUseCase
{
    Task<Response<IEnumerable<ObterHistoricoStatusPedidoUseCaseModel>>> ExecuteAsync(Guid pedidoId);
}