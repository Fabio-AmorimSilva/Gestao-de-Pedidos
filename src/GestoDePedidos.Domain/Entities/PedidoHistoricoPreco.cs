namespace GestoDePedidos.Domain.Entities;

public class PedidoHistoricoPreco : Entity, IAuditableEntity
{
    public Guid PedidoId { get; private set; }
    public Pedido Pedido { get; private set; }
    public decimal Preco { get; private set; }
    
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }

    public PedidoHistoricoPreco(
        Guid pedidoId,
        decimal preco
    )
    {
        Guard.IsNotDefault(pedidoId);
        
        PedidoId = pedidoId;
        Preco = preco;
    }
}