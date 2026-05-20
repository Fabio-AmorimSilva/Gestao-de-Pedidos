namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoStatusPedido;

public record ObterHistoricoStatusPedidoRequest(Guid PedidoId) : PagedRequest;
