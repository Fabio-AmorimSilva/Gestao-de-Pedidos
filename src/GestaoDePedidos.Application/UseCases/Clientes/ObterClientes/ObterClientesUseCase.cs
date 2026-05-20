namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientes;

public class ObterClientesUseCase(IGestaoDePedidosDbContext context) : IObterClientesUseCase
{
    public async Task<Response<IEnumerable<ObterClientesUseCaseModel>>> ExecuteAsync()
    {  
        var clientes = await context.Clientes
            .AsNoTracking()
            .Select(c => new ObterClientesUseCaseModel
            {
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento
            })
            .ToListAsync();

        return new OkResponse<IEnumerable<ObterClientesUseCaseModel>>(clientes);
    }
}