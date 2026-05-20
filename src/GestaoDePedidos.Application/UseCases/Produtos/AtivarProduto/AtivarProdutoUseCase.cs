namespace GestaoDePedidos.Application.UseCases.Produtos.AtivarProduto;

public class AtivarProdutoUseCase(IGestaoDePedidosDbContext context) : IAtivarProdutoUseCase
{
    public async Task<Response> ExecuteAsync(Guid id)
    {
        var produto = await context.Produtos
            .FirstOrDefaultAsync(p => p.Id == id && !p.Ativo);

        if (produto is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Produto>());

        produto.Ativar();
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}