namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoStatusPedido;

public record ObterHistoricoStatusPedidoUseCaseModel
{
    public Guid PedidoId { get; set; }
    public StatusPedido StatusAnterior { get; set; }
    public StatusPedido StatusPosterior { get; set; }
    public DateTime DataAlteracao { get; set; }
    public string? Motivo { get; set; }
}