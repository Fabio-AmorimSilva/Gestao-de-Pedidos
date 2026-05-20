namespace GestaoDePedidos.API.Payloads;

public record AtualizarProdutoUseCaseModelPayload(
    string Nome,
    string Descricao,
    decimal Preco
)
{
    public AtualizarProdutoUseCaseModel AsModel(Guid produtoId)
        => new(
            ProdutoId: produtoId,
            Nome: Nome,
            Descricao: Descricao,
            Preco: Preco
        );
}