namespace GestaoDePedidos.Application.UseCases.Pedidos.ObterPedidoPorId;

public class ObterPedidoPorIdUseCase(IGestaoDePedidosDbContext context) : IObterPedidoPorIdUseCase
{
    public async Task<Response<ObterPedidoPorIdUseCaseModel>> ExecuteAsync(Guid id)
    {
        var pedidos = await context.Pedidos
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new ObterPedidoPorIdUseCaseModel
            {
                Status = p.Status,
                Total = p.Total,
                DataCriacao = p.DataCriacao,
                Itens = p.Itens.Select(i => new ObterPedidoItemPorIdCaseModel
                {
                    Preco = i.Preco,
                    Quantidade = i.Quantidade,
                    Total = i.Total
                })
            }).FirstAsync();
        
        return new OkResponse<ObterPedidoPorIdUseCaseModel>(pedidos);
    }
}