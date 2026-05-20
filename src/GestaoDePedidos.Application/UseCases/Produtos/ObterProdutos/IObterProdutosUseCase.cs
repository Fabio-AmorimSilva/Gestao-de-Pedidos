namespace GestaoDePedidos.Application.UseCases.Produtos.ObterProdutos;

public interface IObterProdutosUseCase
{
    Task<Response<PagedResult<ObterProdutosUseCaseModel>>> ExecuteAsync(PagedRequest request);
}