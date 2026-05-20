namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarEstoque;

public class AtualizarEstoqueUseCase(IGestaoDePedidosDbContext context) : IAtualizarEstoqueUseCase
{
    public async Task<Response> ExecuteAsync(AtualizarEstoqueUseCaseModel model)
    {
        var produto = await context.Produtos
            .FirstOrDefaultAsync(p => p.Id == model.Id);

        if (produto is null)
            return new NotFoundResponse<AtualizarEstoqueUseCaseModel>(ErrorMessages.NotFound<Produto>());

        produto.AtualizarEstoque(estoque: model.Estoque);
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}