namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoPreco;

public record ObterHistoricoPrecoRequest(Guid PedidoId) : PagedRequest;
