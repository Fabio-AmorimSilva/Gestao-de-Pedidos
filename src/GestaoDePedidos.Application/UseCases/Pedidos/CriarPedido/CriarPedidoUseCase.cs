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
            return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Cliente>());
        
        var pedido = new Pedido(clientId: cliente.Id);

        foreach (var item in model.Itens)
        {
            var produto = await context.Produtos.FirstOrDefaultAsync(p =>
                p.Id == item.ProdutoId &&
                p.Estoque >= item.Quantidade &&
                p.Ativo
            );
            
            if(produto is null)
                return new NotFoundResponse<Guid>(ErrorMessages.NotFound<Produto>());

            var pedidoItem = new PedidoItem(
                produtoId: produto.Id,
                quantidade: item.Quantidade,
                preco: produto.Preco
            );

            pedido.AddItem(pedidoItem);
            
            var isEstoqueValido = produto.RemoverEstoque(item.Quantidade);
            
            if(!isEstoqueValido)
                return new UnprocessableResponse<Guid>(ErrorMessages.EstoqueInsuficiente());
        }

        await context.SaveChangesAsync();

        return new CreatedResponse<Guid>(pedido.Id);
    }
}