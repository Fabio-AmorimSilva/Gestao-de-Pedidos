namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidos;

public record ObterPedidosUseCaseModel
{
    public StatusPedido Status { get; set; }
    public decimal Total { get; set; }
    public DateTime DataCriacao { get; set; }
    public IEnumerable<ObterPedidosItemUseCaseModel> Itens { get; set; }
}