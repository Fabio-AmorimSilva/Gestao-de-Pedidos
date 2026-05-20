namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarProduto;

public interface IAtualizarProdutoUseCase
{
    Task<Response> ExecuteAsync(AtualizarProdutoUseCaseModel model);
}