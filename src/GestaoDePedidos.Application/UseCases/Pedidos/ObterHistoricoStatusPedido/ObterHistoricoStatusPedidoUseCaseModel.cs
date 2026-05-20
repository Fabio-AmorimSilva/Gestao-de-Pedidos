namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoStatusPedido;

public record ObterHistoricoStatusPedidoUseCaseModel
{
    public Guid PedidoId { get; init; }
    public StatusPedido StatusAnterior { get; init; }
    public StatusPedido StatusPosterior { get; init; }
    public DateTime DataAlteracao { get; init; }
    public string? Motivo { get; init; }
}