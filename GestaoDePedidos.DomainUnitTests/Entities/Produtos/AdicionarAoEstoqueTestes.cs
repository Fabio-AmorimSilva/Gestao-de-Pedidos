namespace GestaoDePedidos.DomainUnitTests.Entities.Produtos;

public class AdicionarAoEstoqueTestes
{
    [Fact]
    public void AdicionarAoEstoque_DeveIncrementarEstoque()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        produto.AdicionarAoEstoque(5);

        Assert.Equal(15, produto.Estoque);
    }

    [Fact]
    public void AdicionarAoEstoque_RetornaExcecao_EstoqueZero()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        var exception = () => produto.AdicionarAoEstoque(0);

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void AdicionarAoEstoque_RetornaExcecao_EstoqueNegativo()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        var exception = () => produto.AdicionarAoEstoque(-1);

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }
}
