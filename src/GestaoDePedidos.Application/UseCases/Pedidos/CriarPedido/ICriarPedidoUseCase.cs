namespace GestaoDePedidos.Application.UseCases.Pedidos.CriarPedido;

public interface ICriarPedidoUseCase
{
    Task<Response<Guid>> ExecuteAsync(CriarPedidoUseCaseModel model);
}