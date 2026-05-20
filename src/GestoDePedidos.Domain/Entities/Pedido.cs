namespace GestoDePedidos.Domain.Entities;

public class Pedido : Entity
{
    public Guid ClientId { get; private set; }
    public StatusPedido Status { get; private set; }
    public decimal Total { get; private set; }
    public DateTime DataCriacao { get; set; }

    private List<PedidoItem> _itens = [];
    public IReadOnlyCollection<PedidoItem> Itens => _itens;

    public Pedido(
        Guid clientId
    )
    {
        Guard.IsNotDefault(clientId);
        
        ClientId = clientId;
        Status = StatusPedido.Criado;
        Total = TotalItens();
        DataCriacao = DateTime.UtcNow;
    }

    public void StatusPago()
    {
        if (Status is not StatusPedido.Criado)
            throw new Exception($"Um pedido só pode ser pago caso esteja em status {StatusPedido.Criado}");

        Status = StatusPedido.Pago;
    }

    public void StatusEnviado()
    {
        if (Status is not StatusPedido.Pago)
            throw new Exception($"Um pedido só pode ser enviado caso esteja em status {StatusPedido.Pago}");

        Status = StatusPedido.Enviado;
    }

    public void StatusCancelado()
    {
        if (Status is not StatusPedido.Criado)
            throw new Exception($"Um pedido só pode ser cancelado caso esteja em status {StatusPedido.Criado}");

        Status = StatusPedido.Cancelado;
    }

    public void AddItem(PedidoItem item)
        => _itens.Add(item);

    public decimal TotalItens()
        => _itens.Sum(pedidoItem => pedidoItem.Total);
}