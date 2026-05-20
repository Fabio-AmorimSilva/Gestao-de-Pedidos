namespace GestaoDePedidos.Application.UseCases.Clientes.ObterClientePorId;

public record ObterClientePorIdUseCaseModel
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Documento { get; set; } = null!;
}