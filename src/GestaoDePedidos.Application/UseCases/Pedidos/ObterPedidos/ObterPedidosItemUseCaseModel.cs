namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidos;

public record ObterPedidosItemUseCaseModel
{
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
    public decimal Total { get; set; }
}