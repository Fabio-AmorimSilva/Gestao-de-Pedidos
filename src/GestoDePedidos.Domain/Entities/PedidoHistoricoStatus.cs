namespace GestoDePedidos.Domain.Entities;

public class PedidoHistoricoStatus : Entity
{
    public Guid PedidoId { get; private set; }
    public Pedido Pedido { get; private set; }
    public StatusPedido StatusAnterior { get; private set; }
    public StatusPedido StatusPosterior { get; private set; }
    public DateTime DataAlteracao { get; private set; }
    public string? Motivo { get; private set; }

    public PedidoHistoricoStatus(
        Guid pedidoId,
        StatusPedido statusAnterior,
        StatusPedido statusPosterior,
        string? motivo
    )
    {
        PedidoId = pedidoId;
        StatusAnterior = statusAnterior;
        StatusPosterior = statusPosterior;
        DataAlteracao = DateTime.UtcNow;
        Motivo = motivo;
    }
}