namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidos;

public interface IObterPedidosUseCase
{
    Task<Response<PagedResult<ObterPedidosUseCaseModel>>> ExecuteAsync(PagedRequest request);
}