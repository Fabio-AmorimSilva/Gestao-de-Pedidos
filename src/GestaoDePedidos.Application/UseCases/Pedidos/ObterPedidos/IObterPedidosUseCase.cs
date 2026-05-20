namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidos;

public interface IObterPedidosUseCase
{
    Task<Response<IEnumerable<ObterPedidosUseCaseModel>>> ExecuteAsync();
}