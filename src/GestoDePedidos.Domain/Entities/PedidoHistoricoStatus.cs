namespace GestoDePedidos.Domain.Entities;

public class PedidoHistoricoStatus : Entity
{
    public const int MotivoMaxLength = 1500;
    
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
        Guard.IsNotDefault(pedidoId);

        if (!string.IsNullOrWhiteSpace(motivo))
            Guard.IsLessThanOrEqualTo(MotivoMaxLength, motivo.Length, nameof(motivo));
        
        PedidoId = pedidoId;
        StatusAnterior = statusAnterior;
        StatusPosterior = statusPosterior;
        DataAlteracao = DateTime.UtcNow;
        Motivo = motivo;
    }
}