namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientes;

public class ObterClientesUseCase(IGestaoDePedidosDbContext context) : IObterClientesUseCase
{
    public async Task<Response<PagedResult<ObterClientesUseCaseModel>>> ExecuteAsync(PagedRequest request)
    {
        var clientes = await context.Clientes
            .AsNoTracking()
            .Select(c => new ObterClientesUseCaseModel
            {
                ClientId = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento,
                Ativo = c.Ativo
            })
            .ToPagedResultAsync(request);

        return new OkResponse<PagedResult<ObterClientesUseCaseModel>>(clientes);
    }
}