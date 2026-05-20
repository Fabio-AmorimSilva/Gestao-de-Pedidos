namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidoPorId;

public record ObterPedidoPorIdUseCaseModel
{
    public StatusPedido Status { get; init; }
    public decimal Total { get; init; }
    public DateTime DataCriacao { get; init; }
    public IEnumerable<ObterPedidoItemPorIdCaseModel> Itens { get; init; }
}