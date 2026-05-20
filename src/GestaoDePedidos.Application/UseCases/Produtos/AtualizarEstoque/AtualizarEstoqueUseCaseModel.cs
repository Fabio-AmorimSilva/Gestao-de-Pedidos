namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarEstoque;

public record AtualizarEstoqueUseCaseModel(
    Guid ProdutoId,
    int Estoque
);