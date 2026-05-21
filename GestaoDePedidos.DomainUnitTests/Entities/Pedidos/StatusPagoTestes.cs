namespace GestaoDePedidos.DomainUnitTests.Entities.Pedidos;

public class StatusPagoTestes
{
    [Fact]
    public void StatusPago_DeveAlterarStatusParaPago()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());

        pedido.StatusPago();

        Assert.Equal(StatusPedido.Pago, pedido.Status);
    }

    [Fact]
    public void StatusPago_RetornaExcecao_QuandoStatusNaoCriado()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());
        
        pedido.StatusPago();

        var exception = () => pedido.StatusPago();

        Assert.Throws<Exception>(exception);
    }
}
