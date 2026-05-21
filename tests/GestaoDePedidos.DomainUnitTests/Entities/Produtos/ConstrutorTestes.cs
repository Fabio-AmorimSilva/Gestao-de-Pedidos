namespace GestaoDePedidos.DomainUnitTests.Entities.Produtos;

public class ConstrutorTestes
{
    [Fact]
    public void Construtor_Criacao()
    {
        const string nome = "Produto";
        const string descricao = "Descrição do produto";
        const decimal preco = 99.90m;
        const int estoque = 10;

        var produto = new Produto(
            nome: nome,
            descricao: descricao,
            preco: preco,
            estoque: estoque
        );

        Assert.Equal(nome, produto.Nome);
        Assert.Equal(descricao, produto.Descricao);
        Assert.Equal(preco, produto.Preco);
        Assert.Equal(estoque, produto.Estoque);
    }

    [Fact]
    public void Construtor_ProdutoCriadoComoAtivo()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 5
        );

        Assert.True(produto.Ativo);
    }

    [Fact]
    public void Construtor_RetornaExcecao_NomeVazio()
    {
        var exception = () => new Produto(
            nome: string.Empty,
            descricao: "Descrição",
            preco: 10m,
            estoque: 5
        );

        Assert.Throws<ArgumentException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_NomeExcedeuTamanhoMaximo()
    {
        var exception = () => new Produto(
            nome: new string('a', 501),
            descricao: "Descrição",
            preco: 10m,
            estoque: 5
        );

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_EstoqueZero()
    {
        var exception = () => new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 0
        );

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_EstoqueNegativo()
    {
        var exception = () => new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: -1
        );

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }
}
