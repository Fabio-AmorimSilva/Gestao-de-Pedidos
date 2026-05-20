namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoStatusPedido;

public interface IObterHistoricoStatusPedidoUseCase
{
    Task<Response<PagedResult<ObterHistoricoStatusPedidoUseCaseModel>>> ExecuteAsync(ObterHistoricoStatusPedidoRequest request);
}