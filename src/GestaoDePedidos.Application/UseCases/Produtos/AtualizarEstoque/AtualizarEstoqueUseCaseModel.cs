namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarEstoque;

public record AtualizarEstoqueUseCaseModel
{
    public Guid Id { get; set; }
    public int Estoque { get; set; }
}