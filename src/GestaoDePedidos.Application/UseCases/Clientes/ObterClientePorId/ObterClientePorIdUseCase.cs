namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientePorId;

public class ObterClientePorIdUseCase(IGestaoDePedidosDbContext context) : IObterClientePorIdUseCase
{
    public async Task<Response<ObterClientePorIdUseCaseModel>> ExecuteAsync(Guid id)
    {
        var cliente = await context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente is null)
            return new NotFoundResponse<ObterClientePorIdUseCaseModel>(ErrorMessages.NaoEncontrado<Cliente>());

        return new OkResponse<ObterClientePorIdUseCaseModel>(new ObterClientePorIdUseCaseModel
        {
            Nome = cliente.Nome,
            Email = cliente.Email,
            Documento = cliente.Documento
        });
    }
}