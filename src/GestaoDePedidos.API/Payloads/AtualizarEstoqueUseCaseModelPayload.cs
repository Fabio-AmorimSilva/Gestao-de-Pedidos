namespace GestaoDePedidos.API.Payloads;

public record AtualizarEstoqueUseCaseModelPayload(
    int Estoque
)
{
    public AtualizarEstoqueUseCaseModel AsDto(Guid produtoId)
        => new(
            ProdutoId: produtoId,
            Estoque: Estoque
        );
}