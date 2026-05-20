namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientes;

public interface IObterClientesUseCase
{
    Task<Response<PagedResult<ObterClientesUseCaseModel>>> ExecuteAsync(PagedRequest request);
}