namespace GestaoDePedidos.DomainUnitTests.Entities.Clientes;

public class ConstrutorTestes
{
    [Fact]
    public void Construtor_Criacao()
    {
        const string nome = "Cliente";
        const string email = "teste@email.com";
        const string documento = "12345";
        
        var cliente = new Cliente(
             nome: nome,
             email: email,
             documento: documento
        );

        Assert.Equal(nome, cliente.Nome);
        Assert.Equal(email, cliente.Email);
        Assert.Equal(documento, cliente.Documento);
        Assert.True(cliente.Ativo);
    }

    [Fact]
    public void Construtor_RetornaExcecao_NomeVazio()
    {
        var exception = () => new Cliente(
            nome: string.Empty,
            email: "teste@email.com",
            documento: "12345"
        );
        
        Assert.Throws<ArgumentException>(exception);
    }
    
    [Fact]
    public void Construtor_RetornaExcecao_NomeExcedeuTamanhoMaximo()
    {
        var exception = () => new Cliente(
            nome: new string('a', 201),
            email: "teste@email.com",
            documento: "12345"
        );

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_EmailVazio()
    {
        var exception = () => new Cliente(
            nome: "Cliente",
            email: string.Empty,
            documento: "12345"
        );

        Assert.Throws<ArgumentException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_DocumentoVazio()
    {
        var exception = () => new Cliente(
            nome: "Cliente",
            email: "teste@email.com",
            documento: string.Empty
        );

        Assert.Throws<ArgumentException>(exception);
    }
}