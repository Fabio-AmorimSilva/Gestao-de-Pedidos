namespace GestaoDePedidos.Application.UseCases.Produtos.ObterProdutoPorId;

public class ObterProdutoPorIdUseCase(IGestaoDePedidosDbContext context) : IObterProdutoPorIdUseCase
{
    public async Task<Response<ObterProdutoPorIdUseCaseModel>> ExecuteAsync(Guid id)
    {
        var produto = await context.Produtos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (produto is null)
            return new NotFoundResponse<ObterProdutoPorIdUseCaseModel>(ErrorMessages.NaoEncontrado<Produto>());

        return new OkResponse<ObterProdutoPorIdUseCaseModel>(new ObterProdutoPorIdUseCaseModel
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Estoque = produto.Estoque,
            Ativo = produto.Ativo,
            DataCriacao = produto.DataCriacao,
            DataAtualizacao = produto.DataAtualizacao
        });
    }
}