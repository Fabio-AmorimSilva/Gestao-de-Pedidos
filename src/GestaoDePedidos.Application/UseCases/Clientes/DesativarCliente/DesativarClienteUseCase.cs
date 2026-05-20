namespace GestaoDePedidos.Application.UseCases.Clientes.DesativarCliente;

public class DesativarClienteUseCase(IGestaoDePedidosDbContext context) : IDesativarClienteUseCase
{
    public async Task<Response> DesativarClienteAsync(Guid id)
    {
        var cliente = await context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id && c.Ativo);

        if (cliente is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Cliente>());

        cliente.Desativar();

        return new NoContentResponse();
    }
}