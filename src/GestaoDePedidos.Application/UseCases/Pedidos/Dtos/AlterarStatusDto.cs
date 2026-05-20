namespace GestaoDePedidos.Application.UseCases.Pedidos.Dtos;

public record AlterarStatusDto(
    Guid PedidoId,
    string? Motivo
);