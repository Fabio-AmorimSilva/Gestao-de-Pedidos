namespace GestoDePedidos.Domain.Entities;

public class Pedido : Entity
{
    public Guid ClientId { get; private set; }
    public StatusPedido Status { get; private set; }
    public decimal Total { get; private set; }
    public DateTime DataCriacao { get; set; }
    
    private List<PedidoItem> _itens;
    public IReadOnlyCollection<PedidoItem> Itens => _itens;

    public Pedido(
        Guid clientId
    )
    {
        ClientId = clientId;
        Status = StatusPedido.Criado;
        Total = TotalItens();
        DataCriacao = DateTime.UtcNow;
    }
    
    public void AddItem(PedidoItem item)
        => _itens.Add(item);
    
    public decimal TotalItens()
        => _itens.Sum(pedidoItem => pedidoItem.Total);
}  