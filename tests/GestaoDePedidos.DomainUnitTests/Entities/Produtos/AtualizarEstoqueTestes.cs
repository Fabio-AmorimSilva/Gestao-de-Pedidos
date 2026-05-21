namespace GestaoDePedidos.DomainUnitTests.Entities.Produtos;

public class AtualizarEstoqueTestes
{
    [Fact]
    public void AtualizarEstoque_DeveAtualizarEstoque()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        produto.AtualizarEstoque(50);

        Assert.Equal(50, produto.Estoque);
    }

    [Fact]
    public void AtualizarEstoque_RetornaExcecao_EstoqueZero()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        var exception = () => produto.AtualizarEstoque(0);

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void AtualizarEstoque_RetornaExcecao_EstoqueNegativo()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 10
        );

        var exception = () => produto.AtualizarEstoque(-1);

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }
}
