namespace GestaoDePedidos.DomainUnitTests.Entities.Produtos;

public class AtualizarDadosTestes
{
    [Fact]
    public void AtualizarDados_DeveAtualizarNomeDescricaoEPreco()
    {
        var produto = new Produto(
            nome: "Nome antigo",
            descricao: "Descrição antiga",
            preco: 10m,
            estoque: 5
        );

        produto.AtualizarDados(
            nome: "Nome novo",
            descricao: "Descrição nova",
            preco: 99m
        );

        Assert.Equal("Nome novo", produto.Nome);
        Assert.Equal("Descrição nova", produto.Descricao);
        Assert.Equal(99m, produto.Preco);
    }

    [Fact]
    public void AtualizarDados_RetornaExcecao_NomeVazio()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 5
        );

        var exception = () => produto.AtualizarDados(
            nome: string.Empty,
            descricao: "Descrição",
            preco: 10m
        );

        Assert.Throws<ArgumentException>(exception);
    }
}
