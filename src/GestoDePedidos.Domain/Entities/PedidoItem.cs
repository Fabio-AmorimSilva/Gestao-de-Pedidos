namespace GestoDePedidos.Domain.Entities;

public class PedidoItem : Entity
{
    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal Preco { get; private set; }
    public decimal Total { get; private set; }

    public PedidoItem(
        Guid produtoId, 
        int quantidade,
        decimal preco
    )
    {
        ProdutoId = produtoId;
        Quantidade = quantidade;
        Preco = preco;
        Total = TotalItem();
    }
    
    public decimal TotalItem()
        => Quantidade * Preco;
}