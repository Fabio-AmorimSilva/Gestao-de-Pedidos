namespace GestaoDePedidos.Infrastructure.Configurations;

public class PedidoEntityTypeConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder
            .ToTable("Pedidos");

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.ClientId)
            .IsRequired();

        builder
            .Property(p => p.Status)
            .IsRequired();

        builder
            .Property(p => p.Total)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(p => p.DataCriacao)
            .IsRequired();

        builder
            .HasOne<Cliente>()
            .WithMany()
            .HasForeignKey(p => p.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.Itens)
            .WithOne()
            .HasForeignKey(i => i.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
