namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoPreco;

public record ObterHistoricoPrecoUseCaseModel
{
    public Guid PedidoId { get; init; }
    public decimal Preco { get; init; }
    public DateTime DataCriacao { get; init; }
}
