namespace GestaoDePedidos.DomainUnitTests.Entities.Pedidos;

public class StatusEnviadoTestes
{
    [Fact]
    public void StatusEnviado_DeveAlterarStatusParaEnviado()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());
        
        pedido.StatusPago();

        pedido.StatusEnviado();

        Assert.Equal(StatusPedido.Enviado, pedido.Status);
    }

    [Fact]
    public void StatusEnviado_RetornaExcecao_QuandoStatusNaoPago()
    {
        var pedido = new Pedido(clientId: Guid.NewGuid());

        var exception = () => pedido.StatusEnviado();

        Assert.Throws<Exception>(exception);
    }
}
