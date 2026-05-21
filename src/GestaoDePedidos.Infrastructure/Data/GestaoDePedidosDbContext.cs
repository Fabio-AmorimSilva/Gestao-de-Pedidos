namespace GestaoDePedidos.Infrastructure.Data;

public class GestaoDePedidosDbContext(DbContextOptions<GestaoDePedidosDbContext> options) : 
    DbContext(options),
    IGestaoDePedidosDbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<PedidoHistoricoStatus> PedidoHistoricoStatus { get; set; }
    public DbSet<PedidoHistoricoPreco> PedidoHistoricoPreco { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}