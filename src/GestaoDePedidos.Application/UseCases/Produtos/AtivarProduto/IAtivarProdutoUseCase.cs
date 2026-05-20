namespace GestaoDePedidos.Application.UseCases.Produtos.AtivarProduto;

public interface IAtivarProdutoUseCase
{
    Task<Response> ExecuteAsync(Guid id);
}