namespace GestaoDePedidos.Application.UseCases.Pedidos.CriarPedido;

public record CriarPedidoItemUseCaseModel(
    Guid ProdutoId,
    int Quantidade
);