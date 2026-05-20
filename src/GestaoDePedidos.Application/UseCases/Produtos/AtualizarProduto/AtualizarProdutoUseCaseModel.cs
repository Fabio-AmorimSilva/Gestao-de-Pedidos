namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarProduto;

public record AtualizarProdutoUseCaseModel(
    Guid ProdutoId,
    string Nome,
    string Descricao,
    decimal Preco
);