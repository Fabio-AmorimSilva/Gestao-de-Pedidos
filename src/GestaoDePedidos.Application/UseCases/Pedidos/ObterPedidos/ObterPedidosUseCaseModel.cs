namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidos;

public record ObterPedidosUseCaseModel
{
    public Guid PedidoId { get; init; }
    public StatusPedido Status { get; init; }
    public decimal Total { get; init; }
    public DateTime DataCriacao { get; init; }
    public IEnumerable<ObterPedidosItemUseCaseModel> Itens { get; init; }
}