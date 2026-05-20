namespace GestaoDePedidos.Application.UseCases.Pedidos.AlterarStatusPedidoParaPago;

public interface IAlterarStatusPedidoPagoUseCase
{
    Task<Response> ExecuteAsync(AlterarStatusDto dto);
}