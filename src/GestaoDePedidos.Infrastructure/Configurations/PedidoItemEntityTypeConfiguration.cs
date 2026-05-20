namespace GestaoDePedidos.Infrastructure.Configurations;

public class PedidoItemEntityTypeConfiguration : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder
            .ToTable("PedidoItens");

        builder
            .HasKey(i => i.Id);

        builder
            .Property(i => i.PedidoId)
            .IsRequired();

        builder
            .Property(i => i.ProdutoId)
            .IsRequired();

        builder
            .Property(i => i.Quantidade)
            .IsRequired();

        builder
            .Property(i => i.Preco)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(i => i.Total)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .HasOne<Produto>()
            .WithMany()
            .HasForeignKey(i => i.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
