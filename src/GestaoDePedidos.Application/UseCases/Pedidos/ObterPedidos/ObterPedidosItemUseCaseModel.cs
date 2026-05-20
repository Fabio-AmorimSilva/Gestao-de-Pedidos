namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidos;

public record ObterPedidosItemUseCaseModel
{
    public Guid ItemId { get; init; }
    public int Quantidade { get; init; }
    public decimal Preco { get; init; }
    public decimal Total { get; init; }
}