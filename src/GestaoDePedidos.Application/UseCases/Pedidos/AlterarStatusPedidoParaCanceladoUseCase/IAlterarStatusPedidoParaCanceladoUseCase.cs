namespace GestaoDePedidos.Application.UseCases.Pedidos.AlterarStatusPedidoParaCanceladoUseCase;

public interface IAlterarStatusPedidoParaCanceladoUseCase
{
    Task<Response> ExecuteAsync(AlterarStatusDto dto);
}