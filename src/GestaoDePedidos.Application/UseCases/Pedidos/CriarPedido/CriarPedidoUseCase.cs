namespace GestaoDePedidos.Application.UseCases.Pedidos.CriarPedido;

public class CriarPedidoUseCase(IGestaoDePedidosDbContext context) : ICriarPedidoUseCase
{
    public async Task<Response<Guid>> ExecuteAsync(CriarPedidoUseCaseModel model)
    {
        var cliente = await context.Clientes
            .FirstOrDefaultAsync(c =>
                c.Id == model.ClienteId &&
                c.Ativo
            );

        if (cliente is null)
            return new NotFoundResponse<Guid>(ErrorMessages.NaoEncontrado<Cliente>());
        
        var pedido = new Pedido(clientId: cliente.Id);

        foreach (var item in model.Itens)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(p => p.Id == item.ProdutoId);
            
            if(produto is null)
                return new NotFoundResponse<Guid>(ErrorMessages.NaoEncontrado<Produto>());
            
            if(!produto.Ativo)
                return new UnprocessableResponse<Guid>(ErrorMessages.ProdutoInativo());
                
            var isEstoqueValido = produto.RemoverDoEstoque(item.Quantidade);
            
            if(!isEstoqueValido)
                return new UnprocessableResponse<Guid>(ErrorMessages.EstoqueInsuficiente());
            
            var pedidoItem = new PedidoItem(
                produtoId: produto.Id,
                quantidade: item.Quantidade,
                preco: produto.Preco
            );
            
            pedido.AddItem(pedidoItem);
            
            await context.Pedidos.AddAsync(pedido);
        }
        
        var historico = new PedidoHistoricoPreco(
            pedidoId: pedido.Id,
            preco: pedido.TotalItens()
        );
        
        await context.PedidoHistoricoPreco.AddAsync(historico);       
        await context.SaveChangesAsync();

        return new CreatedResponse<Guid>(pedido.Id);
    }
}