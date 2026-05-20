namespace GestaoDePedidos.API.Payloads;

public record AlterarStatusDtoPayload(
    string? Motivo
)
{
    public AlterarStatusDto AsDto(Guid pedidoId)
     => new(
         PedidoId: pedidoId, 
         Motivo: Motivo
        );
}

