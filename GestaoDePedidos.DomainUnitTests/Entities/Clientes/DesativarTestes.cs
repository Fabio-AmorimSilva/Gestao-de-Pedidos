namespace GestaoDePedidos.DomainUnitTests.Entities.Clientes;

public class DesativarTestes
{
    [Fact]
    public void Desativar_DeveSetarAtivoParaFalso()
    {
        var cliente = new Cliente(
            nome: "Cliente",
            email: "teste@email.com",
            documento: "12345"
        );

        cliente.Desativar();

        Assert.False(cliente.Ativo);
    }
}