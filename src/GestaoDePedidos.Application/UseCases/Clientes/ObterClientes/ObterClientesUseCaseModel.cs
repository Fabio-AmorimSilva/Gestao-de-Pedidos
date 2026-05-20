namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientes;

public record ObterClientesUseCaseModel
{
    public Guid ClientId { get; init; }
    public string Nome { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Documento { get; init; } = null!;
    public bool Ativo { get; init; }
}