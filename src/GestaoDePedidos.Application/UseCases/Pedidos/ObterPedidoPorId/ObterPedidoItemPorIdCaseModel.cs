namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidoPorId;

public record ObterPedidoItemPorIdCaseModel
{
    public Guid ItemId { get; init; }
    public int Quantidade { get; init; }
    public decimal Preco { get; init; }
    public decimal Total { get; init; }
}