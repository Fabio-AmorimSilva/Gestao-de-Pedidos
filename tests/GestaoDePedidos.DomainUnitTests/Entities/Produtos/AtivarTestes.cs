namespace GestaoDePedidos.DomainUnitTests.Entities.Produtos;

public class AtivarTestes
{
    [Fact]
    public void Ativar_DeveSetarAtivoParaVerdadeiro()
    {
        var produto = new Produto(
            nome: "Produto",
            descricao: "Descrição",
            preco: 10m,
            estoque: 5
        );
        
        produto.Desativar();

        produto.Ativar();

        Assert.True(produto.Ativo);
    }
}
