namespace GestaoDePedidos.Application.UseCases.Produtos.ObterProdutos;

public class ObterProdutosUseCase(IGestaoDePedidosDbContext context) : IObterProdutosUseCase
{
    public async Task<Response<IEnumerable<ObterProdutosUseCaseModel>>> ExecuteAsync()
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
                DataCriacao = p.DataCriacao,
                DataAtualizacao = p.DataAtualizacao
            })
            .ToListAsync();

        return new OkResponse<IEnumerable<ObterProdutosUseCaseModel>>(produtos);
    }
}