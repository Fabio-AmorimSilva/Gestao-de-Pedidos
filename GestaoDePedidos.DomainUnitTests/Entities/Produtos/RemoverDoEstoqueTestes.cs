namespace GestaoDePedidos.DomainUnitTests.Entities.Produtos;

public class RemoverDoEstoqueTestes
{
    [Fact]
    public void RemoverDoEstoque_DeveRemoverEstoque()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        var resultado = produto.RemoverDoEstoque(3);

        Assert.True(resultado);
        Assert.Equal(7, produto.Estoque);
    }

    [Fact]
    public void RemoverDoEstoque_EstoqueInsuficiente_DeveRetornarFalso()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 5
        );

        var resultado = produto.RemoverDoEstoque(10);

        Assert.False(resultado);
        Assert.Equal(5, produto.Estoque);
    }

    [Fact]
    public void RemoverDoEstoque_RetornaExcecao_EstoqueZero()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        var exception = () => { produto.RemoverDoEstoque(0); };

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void RemoverDoEstoque_RetornaExcecao_EstoqueNegativo()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        var exception = () => { produto.RemoverDoEstoque(-1); };

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }
}
