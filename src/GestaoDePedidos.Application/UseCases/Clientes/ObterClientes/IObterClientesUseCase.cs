namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientes;

public interface IObterClientesUseCase
{
    Task<Response<IEnumerable<ObterClientesUseCaseModel>>> ExecuteAsync();
}