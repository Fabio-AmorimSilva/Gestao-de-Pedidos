namespace GestoDePedidos.Domain.Entities;

public class Pedido : Entity
{
    public Guid ClientId { get; private set; }
    public StatusPedido Status { get; set; }
    public decimal Total { get; private set; }
    public DateTime DataCriacao { get; set; }
    
    private IReadOnlyCollection<PedidoItem> _itens;
    public IReadOnlyCollection<PedidoItem> Itens => _itens;

    public Pedido(
        Guid clientId, 
        StatusPedido status,
        decimal total
    )
    {
        ClientId = clientId;
        Status = status;
        Total = total;
        DataCriacao = DateTime.UtcNow;
    }
}  