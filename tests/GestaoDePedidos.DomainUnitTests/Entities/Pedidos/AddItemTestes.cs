namespace GestaoDePedidos.DomainUnitTests.Entities.Pedidos;

public class AddItemTestes
{
    [Fact]
    public void AddItem_DeveAdicionarItem()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());
        var item = new PedidoItem(
            produtoId: Guid.NewGuid(),
            quantidade: 1,
            preco: 10m
        );

        pedido.AddItem(item);

        Assert.Single(pedido.Itens);
    }

    [Fact]
    public void AddItem_DeveAdicionarMultiplosItens()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());
        var item1 = new PedidoItem(
            produtoId: Guid.NewGuid(),
            quantidade: 1,
            preco: 10m
        );
        var item2 = new PedidoItem(
            produtoId: Guid.NewGuid(),
            quantidade: 2,
            preco: 20m
        );

        pedido.AddItem(item1);
        pedido.AddItem(item2);

        Assert.Equal(2, pedido.Itens.Count);
    }
}
