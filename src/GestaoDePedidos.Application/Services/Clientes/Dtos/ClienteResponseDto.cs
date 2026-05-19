namespace GestaoDePedidos.Application.Services.Clientes.Dtos;

public record ClienteResponseDto
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Documento { get; set; } = null!;
}