namespace GestaoDePedidos.DomainUnitTests.Entities.Produtos;

public class DesativarTestes
{
    [Fact]
    public void Desativar_DeveSetarAtivoParaFalso()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 5
        );

        produto.Desativar();

        Assert.False(produto.Ativo);
    }
}
