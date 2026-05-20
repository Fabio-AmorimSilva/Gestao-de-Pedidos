namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientePorId;

public interface IObterClientePorIdUseCase
{
    Task<Response<ObterClientePorIdUseCaseModel>> ExecuteAsync(Guid id);
}