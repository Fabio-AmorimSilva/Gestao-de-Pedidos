namespace GestaoDePedidos.DomainUnitTests.Entities.PedidosHistoricosStatus;

public class ConstrutorTestes
{
    [Fact]
    public void Construtor_Criacao()
    {
        var pedidoId = Guid.NewGuid();
        const StatusPedido statusAnterior = StatusPedido.Criado;
        const StatusPedido statusPosterior = StatusPedido.Pago;
        const string motivo = "Pagamento confirmado";

        var historico = new PedidoHistoricoStatus(
            pedidoId: pedidoId,
            statusAnterior: statusAnterior,
            statusPosterior: statusPosterior,
            motivo: motivo
        );

        Assert.Equal(pedidoId, historico.PedidoId);
        Assert.Equal(statusAnterior, historico.StatusAnterior);
        Assert.Equal(statusPosterior, historico.StatusPosterior);
        Assert.Equal(motivo, historico.Motivo);
    }

    [Fact]
    public void Construtor_Criacao_ComMotivoNulo()
    {
        var historico = new PedidoHistoricoStatus(
            pedidoId: Guid.NewGuid(),
            statusAnterior: StatusPedido.Criado,
            statusPosterior: StatusPedido.Pago,
            motivo: null
        );

        Assert.Null(historico.Motivo);
    }

    [Fact]
    public void Construtor_RetornaExcecao_PedidoIdPadrao()
    {
        var exception = () => new PedidoHistoricoStatus(
            pedidoId: Guid.Empty,
            statusAnterior: StatusPedido.Criado,
            statusPosterior: StatusPedido.Pago,
            motivo: null
        );

        Assert.Throws<ArgumentException>(exception);
    }
}
