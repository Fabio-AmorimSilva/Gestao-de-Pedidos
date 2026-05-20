namespace GestaoDePedidos.Application.UseCases.Produtos.CadastrarProduto;

public record CadastrarProdutoUseCaseModel(
    string Nome,
    string Descricao,
    decimal Preco,
    int Estoque
);