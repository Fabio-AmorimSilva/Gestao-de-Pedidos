namespace GestaoDePedidos.Infrastructure.Configurations;

public class PedidoHistoricoPrecoEntityTypeConfiguration : IEntityTypeConfiguration<PedidoHistoricoPreco>
{
    public void Configure(EntityTypeBuilder<PedidoHistoricoPreco> builder)
    {
        builder
            .ToTable("PedidoHistoricosPreco");

        builder
            .HasKey(php => php.Id);

        builder
            .Property(php => php.PedidoId)
            .IsRequired();

        builder
            .Property(php => php.Preco)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(php => php.DataCriacao)
            .IsRequired();

        builder
            .Property(php => php.DataAtualizacao)
            .IsRequired(false);

        builder
            .HasOne<Pedido>(php => php.Pedido)
            .WithMany()
            .HasForeignKey(php => php.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
