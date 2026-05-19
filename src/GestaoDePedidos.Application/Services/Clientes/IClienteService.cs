namespace GestaoDePedidos.Application.Services.Clientes;

public interface IClienteService
{
    Task<Response<Guid>> CriarClienteAsync(Cliente dto);
    Task<Response<ClienteResponseDto>> ObterClientePorIdAsync(Guid id);
    Task<Response<IEnumerable<ClienteResponseDto>>> ObterClientesAsync();
    Task<Response> DesativarClienteAsync(Guid id);
}