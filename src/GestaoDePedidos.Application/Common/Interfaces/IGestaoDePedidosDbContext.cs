namespace GestaoDePedidos.Application.Common.Interfaces;

public interface IGestaoDePedidosDbContext
{
    DbSet<Cliente> Clientes { get; set; }
    DbSet<Pedido> Pedidos { get; set; }
    DbSet<Produto> Produtos { get; set; }
    DbSet<PedidoHistoricoStatus>  PedidoHistoricoStatus { get; set; }
    DbSet<PedidoHistoricoPreco> PedidoHistoricoPreco { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}