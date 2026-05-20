namespace GestaoDePedidos.Application.UseCases.Produtos.ObterProdutos;

public class ObterProdutosUseCase(IGestaoDePedidosDbContext context) : IObterProdutosUseCase
{
    public async Task<Response<PagedResult<ObterProdutosUseCaseModel>>> ExecuteAsync(PagedRequest request)
    {
        var produtos = await context.Produtos
            .AsNoTracking()
            .Select(p => new ObterProdutosUseCaseModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Estoque = p.Estoque,
                Ativo = p.Ativo,
                DataCriacao = p.DataCriacao.Date,
                DataAtualizacao = p.DataAtualizacao.Value.Date
            })
            .ToPagedResultAsync(request);

        return new OkResponse<PagedResult<ObterProdutosUseCaseModel>>(produtos);
    }
}