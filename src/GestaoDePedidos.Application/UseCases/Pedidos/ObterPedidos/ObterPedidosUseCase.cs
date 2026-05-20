namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidos;

public class ObterPedidosUseCase(IGestaoDePedidosDbContext context) : IObterPedidosUseCase
{
    public async Task<Response<PagedResult<ObterPedidosUseCaseModel>>> ExecuteAsync(PagedRequest request)
    {
        var pedidos = await context.Pedidos
            .AsNoTracking()
            .Select(p => new ObterPedidosUseCaseModel
            {
                Status = p.Status,
                Total = p.Total,
                DataCriacao = p.DataCriacao,
                Itens = p.Itens.Select(i => new ObterPedidosItemUseCaseModel
                {
                    Preco = i.Preco,
                    Quantidade = i.Quantidade,
                    Total = i.Total
                })
            }).ToPagedResultAsync(request);
        
        return new OkResponse<PagedResult<ObterPedidosUseCaseModel>>(pedidos);
    }
}