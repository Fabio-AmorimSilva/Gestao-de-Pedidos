namespace GestaoDePedidos.Application.UseCases.Pedidos.Dtos;

public record AlterarStatusDto
{
    public Guid PedidoId { get; init; }
    public string? Motivo { get; init; }
}