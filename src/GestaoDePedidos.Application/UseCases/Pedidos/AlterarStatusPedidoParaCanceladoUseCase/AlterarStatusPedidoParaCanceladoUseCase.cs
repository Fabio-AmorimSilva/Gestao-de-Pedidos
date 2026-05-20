namespace GestaoDePedidos.Application.UseCases.Pedidos.AlterarStatusPedidoParaCanceladoUseCase;

public class AlterarStatusPedidoParaCanceladoUseCase(IGestaoDePedidosDbContext context) : IAlterarStatusPedidoParaCanceladoUseCase
{
    public async Task<Response> ExecuteAsync(AlterarStatusDto dto)
    {
        var pedido = await context.Pedidos.FirstOrDefaultAsync(p => p.Id == dto.PedidoId);
        
        if(pedido is null)
            return new NotFoundResponse<Pedido>(ErrorMessages.NotFound<Pedido>());
        
        var produtosIds = context.Pedidos
            .SelectMany(p => p.Itens)
            .Select(produto => produto.ProdutoId);
        
        var produtosExists = await context.Produtos
            .AnyAsync(p => produtosIds.Contains(p.Id));
            
        if(!produtosExists)
            return new NotFoundResponse<Produto>(ErrorMessages.NotFound<Produto>());
        
        var statusAnterior = pedido.Status;
        pedido.StatusCancelado();
        
        var itens = pedido.Itens;

        foreach (var item in itens)
        {
            var produto = await context.Produtos.FirstAsync(p => p.Id == item.ProdutoId);
            produto.AdicionarAoEstoque(item.Quantidade);
        }
        
        var historico = new PedidoHistoricoStatus(
            pedidoId: pedido.Id,
            statusAnterior: statusAnterior,
            statusPosterior: pedido.Status,
            motivo: dto.Motivo
        );
        
        await context.PedidoHistoricoStatus.AddAsync(historico);
        
        await context.SaveChangesAsync();

        return new NoContentResponse();
    }
}