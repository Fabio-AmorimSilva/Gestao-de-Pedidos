namespace GestaoDePedidos.Application.UseCases.Clientes.CriarCliente;

public interface ICriarClienteUseCase
{
    Task<Response<Guid>> ExecuteAsync(CriarClienteUseCaseModel dto);
}