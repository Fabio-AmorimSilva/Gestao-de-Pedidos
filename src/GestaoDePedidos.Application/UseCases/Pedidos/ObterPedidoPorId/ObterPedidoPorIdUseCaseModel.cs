namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidoPorId;

public record ObterPedidoPorIdUseCaseModel
{
    public StatusPedido Status { get; set; }
    public decimal Total { get; set; }
    public DateTime DataCriacao { get; set; }
    public IEnumerable<ObterPedidoItemPorIdCaseModel> Itens { get; set; }
}