namespace GestaoDePedidos.Application.UseCases.Produtos.CadastrarProduto;

public class CadastrarProdutoUseCase(IGestaoDePedidosDbContext context) : ICadastrarProdutoUseCase
{
    public async Task<Response<Guid>> ExecuteAsync(CadastrarProdutoUseCaseModel model)
    {
        var produto = new Produto(
            nome: model.Nome,
            descricao: model.Descricao,
            preco: model.Preco,
            estoque: model.Estoque
        );

        await context.Produtos.AddAsync(produto);
        await context.SaveChangesAsync();

        return new CreatedResponse<Guid>(produto.Id);
    }
}