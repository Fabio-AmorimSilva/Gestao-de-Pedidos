namespace GestaoDePedidos.DomainUnitTests.Specifications;

public class DocumentAlreadyExistsTestes
{
    [Fact]
    public void DocumentAlreadyExists_DeveRetornarVerdadeiro_QuandoDocumentoExisteEClienteAtivo()
    {
        const string documento = "12345";
        var cliente = new Cliente(
            nome: "Cliente",
            email: "teste@email.com",
            documento: documento
        );
        
        var spec = new DocumentAlreadyExists(documento);
        
        var filtro = spec.WhereExpressions
            .First()
            .Filter
            .Compile();

        var resultado = filtro(cliente);

        Assert.True(resultado);
    }

    [Fact]
    public void DocumentAlreadyExists_DeveRetornarFalso_QuandoDocumentoNaoCorresponde()
    {
        var cliente = new Cliente(
            nome: "Cliente",
            email: "teste@email.com",
            documento: "99999"
        );
        var spec = new DocumentAlreadyExists("12345");
        
        var filtro = spec.WhereExpressions
            .First()
            .Filter
            .Compile();

        var resultado = filtro(cliente);

        Assert.False(resultado);
    }

    [Fact]
    public void DocumentAlreadyExists_DeveRetornarFalso_QuandoClienteInativo()
    {
        const string documento = "12345";
        var cliente = new Cliente(
            nome: "Cliente",
            email: "teste@email.com",
            documento: documento
        );
        
        cliente.Desativar();
        
        var spec = new DocumentAlreadyExists(documento);
        
        var filtro = spec.WhereExpressions
            .First()
            .Filter
            .Compile();

        var resultado = filtro(cliente);

        Assert.False(resultado);
    }
}
