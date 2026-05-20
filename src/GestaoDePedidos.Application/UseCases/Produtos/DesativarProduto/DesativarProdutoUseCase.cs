namespace GestaoDePedidos.Application.UseCases.Produtos.DesativarProduto;

public class DesativarProdutoUseCase(IGestaoDePedidosDbContext context) : IDesativarProdutoUseCase
{
    public async Task<Response> ExecuteAsync(Guid id)
    {
        var produto = await context.Produtos
            .FirstOrDefaultAsync(p => p.Id == id && p.Ativo);

        if (produto is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NaoEncontrado<Produto>());

        produto.Desativar();
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}