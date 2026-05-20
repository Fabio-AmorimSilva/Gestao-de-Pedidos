namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidoPorId;

public interface IObterPedidoPorIdUseCase
{
    Task<Response<ObterPedidoPorIdUseCaseModel>> ExecuteAsync(Guid id);
}