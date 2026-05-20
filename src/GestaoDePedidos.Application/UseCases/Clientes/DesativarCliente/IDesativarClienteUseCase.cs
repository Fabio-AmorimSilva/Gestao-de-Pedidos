namespace GestaoDePedidos.Application.UseCases.Clientes.DesativarCliente;

public interface IDesativarClienteUseCase
{
    Task<Response> DesativarClienteAsync(Guid id);
}