namespace GestaoDePedidos.DomainUnitTests.Entities.PedidoItens;

public class ConstrutorTestes
{
    [Fact]
    public void Construtor_Criacao()
    {
        var produtoId = Guid.NewGuid();
        const int quantidade = 3;
        const decimal preco = 25m;

        var item = new PedidoItem(
            produtoId: produtoId,
            quantidade: quantidade,
            preco: preco
        );

        Assert.Equal(produtoId, item.ProdutoId);
        Assert.Equal(quantidade, item.Quantidade);
        Assert.Equal(preco, item.Preco);
        Assert.Equal(quantidade * preco, item.Total);
    }

    [Fact]
    public void Construtor_RetornaExcecao_ProdutoIdPadrao()
    {
        var exception = () => new PedidoItem(
            produtoId: Guid.Empty,
            quantidade: 1,
            preco: 10m
        );

        Assert.Throws<ArgumentException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_QuantidadeZero()
    {
        var exception = () => new PedidoItem(
            produtoId: Guid.NewGuid(),
            quantidade: 0,
            preco: 10m
        );

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_QuantidadeNegativa()
    {
        var exception = () => new PedidoItem(
            produtoId: Guid.NewGuid(),
            quantidade: -1,
            preco: 10m
        );

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_PrecoZero()
    {
        var exception = () => new PedidoItem(
            produtoId: Guid.NewGuid(),
            quantidade: 1,
            preco: 0m
        );

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void Construtor_RetornaExcecao_PrecoNegativo()
    {
        var exception = () => new PedidoItem(
            produtoId: Guid.NewGuid(),
            quantidade: 1,
            preco: -1m
        );

        Assert.Throws<ArgumentOutOfRangeException>(exception);
    }
}
