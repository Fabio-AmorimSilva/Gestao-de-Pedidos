namespace GestaoDePedidos.Application.UseCases.Pedidos.CriarPedido;

public record CriarPedidoUseCaseModel(
    Guid ClienteId,
    IEnumerable<CriarPedidoItemUseCaseModel> Itens
);

