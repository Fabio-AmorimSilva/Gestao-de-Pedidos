namespace GestaoDePedidos.Application.Services.Clientes;

public class ClienteService(IGestaoDePedidosDbContext context) : IClienteService
{
    public async Task<Response<Guid>> CriarClienteAsync(Cliente dto)
    {
        var cliente = new Cliente(
            dto.Nome,
            dto.Email,
            dto.Documento
        );

        var emailAlreadyExists = await context.Clientes
            .WithSpecification(new EmailAlreadyExists(cliente.Email))
            .AnyAsync();

        if (emailAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(cliente.Email)));

        var documentoAlreadyExists = await context.Clientes
            .WithSpecification(new DocumentAlreadyExists(cliente.Documento))
            .AnyAsync();

        if (documentoAlreadyExists)
            return new UnprocessableResponse<Guid>(ErrorMessages.MustBeUnique(nameof(cliente.Documento)));

        await context.Clientes.AddAsync(cliente);
        await context.SaveChangesAsync();

        return new CreatedResponse<Guid>(cliente.Id);
    }

    public async Task<Response<ClienteResponseDto>> ObterClientePorIdAsync(Guid id)
    {
        var cliente = await context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente is null)
            return new NotFoundResponse<ClienteResponseDto>(ErrorMessages.NotFound<Cliente>());

        return new OkResponse<ClienteResponseDto>(new ClienteResponseDto
        {
            Nome = cliente.Nome,
            Email = cliente.Email,
            Documento = cliente.Documento
        });
    }

    public async Task<Response<IEnumerable<ClienteResponseDto>>> ObterClientesAsync()
    {
        var clientes = await context.Clientes
            .AsNoTracking()
            .Select(c => new ClienteResponseDto
            {
                Nome = c.Nome,
                Email = c.Email,
                Documento = c.Documento
            })
            .ToListAsync();

        return new OkResponse<IEnumerable<ClienteResponseDto>>(clientes);
    }

    public async Task<Response> DesativarClienteAsync(Guid id)
    {
        var cliente = await context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id && c.Ativo);

        if (cliente is null)
            return new NotFoundResponse<ClienteResponseDto>(ErrorMessages.NotFound<Cliente>());

        cliente.Desativar();

        return new NoContentResponse();
    }
}