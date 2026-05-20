namespace GestaoDePedidos.Application.UseCases.Pedidos.AlterarStatusPedidoEnviadoUseCase;

public interface IAlterarStatusPedidoEnviadoUseCase
{
    Task<Response> ExecuteAsync(AlterarStatusDto dto);
}