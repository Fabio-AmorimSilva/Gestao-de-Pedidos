namespace GestaoDePedidos.DomainUnitTests.Specifications;

public class EmailAlreadyExistsTestes
{
    [Fact]
    public void EmailAlreadyExists_DeveRetornarVerdadeiro_QuandoEmailExisteEClienteAtivo()
    {
        const string email = "teste@email.com";
        var cliente = new Cliente(
            nome: "Cliente",
            email: email,
            documento: "12345"
        );
        
        var spec = new EmailAlreadyExists(email);
        
        var filtro = spec.WhereExpressions
            .First()
            .Filter
            .Compile();

        var resultado = filtro(cliente);

        Assert.True(resultado);
    }

    [Fact]
    public void EmailAlreadyExists_DeveRetornarFalso_QuandoEmailNaoCorresponde()
    {
        var cliente = new Cliente(
            nome: "Cliente",
            email: "outro@email.com",
            documento: "12345"
        );
        var spec = new EmailAlreadyExists("teste@email.com");
        
        var filtro = spec.WhereExpressions
            .First()
            .Filter
            .Compile();

        var resultado = filtro(cliente);

        Assert.False(resultado);
    }

    [Fact]
    public void EmailAlreadyExists_DeveRetornarFalso_QuandoClienteInativo()
    {
        const string email = "teste@email.com";
        var cliente = new Cliente(
            nome: "Cliente",
            email: email,
            documento: "12345"
        );
        
        cliente.Desativar();
        
        var spec = new EmailAlreadyExists(email);
        
        var filtro = spec.WhereExpressions
            .First()
            .Filter
            .Compile();

        var resultado = filtro(cliente);

        Assert.False(resultado);
    }
}
