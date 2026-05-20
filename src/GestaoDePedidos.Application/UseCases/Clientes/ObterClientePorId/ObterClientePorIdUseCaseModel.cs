namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientePorId;

public record ObterClientePorIdUseCaseModel
{
    public string Nome { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Documento { get; init; } = null!;
}