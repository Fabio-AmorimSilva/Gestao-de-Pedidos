namespace GestoDePedidos.Domain.Entities;

public class PedidoItem : Entity
{
    public const int QuantidadeTamanhoMinimo = 0;
    public const int PrecoTamanhoMinimo = 0;
    
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
        Guard.IsNotDefault(produtoId);
        Guard.IsGreaterThan(quantidade, QuantidadeTamanhoMinimo);
        Guard.IsGreaterThan(preco, PrecoTamanhoMinimo);
        
        ProdutoId = produtoId;
        Quantidade = quantidade;
        Preco = preco;
        Total = quantidade * preco;
    }
}