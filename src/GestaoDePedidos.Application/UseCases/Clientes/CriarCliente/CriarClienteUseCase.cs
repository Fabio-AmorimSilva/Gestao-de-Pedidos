namespace GestaoDePedidos.Application.UseCases.Clientes.CriarCliente;

public class CriarClienteUseCase(IGestaoDePedidosDbContext context) : ICriarClienteUseCase
{
    public async Task<Response<Guid>> ExecuteAsync(CriarClienteUseCaseModel dto)
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
}