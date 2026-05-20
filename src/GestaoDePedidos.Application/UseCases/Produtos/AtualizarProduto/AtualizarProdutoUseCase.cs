namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarProduto;

public class AtualizarProdutoUseCase(IGestaoDePedidosDbContext context) : IAtualizarProdutoUseCase
{
    public async Task<Response> ExecuteAsync(AtualizarProdutoUseCaseModel model)
    {
        var produto = await context.Produtos
            .FirstOrDefaultAsync(p => p.Id == model.Id);

        if (produto is null)
            return new NotFoundResponse<AtualizarProdutoUseCaseModel>(ErrorMessages.NotFound<Produto>());

        produto.AtualizarDados(
            nome: model.Nome,
            descricao: model.Descricao,
            preco: model.Preco
        );
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}