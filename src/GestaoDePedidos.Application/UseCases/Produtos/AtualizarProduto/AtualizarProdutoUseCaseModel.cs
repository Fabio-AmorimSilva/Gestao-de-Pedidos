namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarProduto;

public record AtualizarProdutoUseCaseModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
}