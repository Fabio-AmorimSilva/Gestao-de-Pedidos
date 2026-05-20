namespace GestaoDePedidos.Application.UseCases.Produtos.ObterProdutoPorId;

public interface IObterProdutoPorIdUseCase
{
    Task<Response<ObterProdutoPorIdUseCaseModel>> ExecuteAsync(Guid id);
}