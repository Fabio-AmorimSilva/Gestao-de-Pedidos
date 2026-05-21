namespace GestaoDePedidos.DomainUnitTests.Entities.Pedidos;

public class ConstrutorTestes
{
    [Fact]
    public void Construtor_Criacao()
    {
        var clientId = Guid.NewGuid();

        var pedido = new Pedido(clientId: clientId);

        Assert.Equal(clientId, pedido.ClientId);
        Assert.Equal(StatusPedido.Criado, pedido.Status);
        Assert.Equal(0, pedido.Total);
        Assert.Empty(pedido.Itens);
    }

    [Fact]
    public void Construtor_RetornaExcecao_ClientIdPadrao()
    {
        var exception = () => new Pedido(clientId: Guid.Empty);

        Assert.Throws<ArgumentException>(exception);
    }
}
