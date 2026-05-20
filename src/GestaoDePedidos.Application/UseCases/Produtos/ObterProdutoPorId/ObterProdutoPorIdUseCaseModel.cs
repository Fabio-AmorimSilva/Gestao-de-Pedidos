namespace GestaoDePedidos.Application.UseCases.Produtos.ObterProdutoPorId;

public record ObterProdutoPorIdUseCaseModel
{
    public Guid ProdutoId { get; init; }
    public string Nome { get; init; } = null!;
    public string Descricao { get; init; } = null!;
    public decimal Preco { get; init; }
    public int Estoque { get; init; }
    public bool Ativo { get; init; }
    public DateTime DataCriacao { get; init; }
    public DateTime? DataAtualizacao { get; init; }
}