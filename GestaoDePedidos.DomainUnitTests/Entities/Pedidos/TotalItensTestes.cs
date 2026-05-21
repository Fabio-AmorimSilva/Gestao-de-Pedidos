namespace GestaoDePedidos.DomainUnitTests.Entities.Pedidos;

public class TotalItensTestes
{
    [Fact]
    public void TotalItens_SemItens_DeveRetornarZero()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());

        var total = pedido.TotalItens();

        Assert.Equal(0, total);
    }

    [Fact]
    public void TotalItens_ComItens_DeveRetornarSomaDosItens()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());
        
        pedido.AddItem(
            new PedidoItem(
                produtoId: Guid.NewGuid(),
                quantidade: 2,
                preco: 15m
            ));
        
        pedido.AddItem(
            new PedidoItem(
                produtoId: Guid.NewGuid(),
                quantidade: 3,
                preco: 10m
            ));

        var total = pedido.TotalItens();

        Assert.Equal(60m, total);
    }
}