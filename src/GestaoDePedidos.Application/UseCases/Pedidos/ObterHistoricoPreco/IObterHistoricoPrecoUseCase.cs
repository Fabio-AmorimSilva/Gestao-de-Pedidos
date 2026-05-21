namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterHistoricoPreco;

public interface IObterHistoricoPrecoUseCase
{
    Task<Response<PagedResult<ObterHistoricoPrecoUseCaseModel>>> ExecuteAsync(ObterHistoricoPrecoRequest request);
}
