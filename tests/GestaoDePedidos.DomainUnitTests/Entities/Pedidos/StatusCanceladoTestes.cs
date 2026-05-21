namespace GestaoDePedidos.DomainUnitTests.Entities.Pedidos;

public class StatusCanceladoTestes
{
    [Fact]
    public void StatusCancelado_DeveAlterarStatusParaCancelado()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());

        pedido.StatusCancelado();

        Assert.Equal(StatusPedido.Cancelado, pedido.Status);
    }

    [Fact]
    public void StatusCancelado_RetornaExcecao_QuandoStatusNaoCriado()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());
        
        pedido.StatusPago();

        var exception = () => pedido.StatusCancelado();

        Assert.Throws<Exception>(exception);
    }
}
