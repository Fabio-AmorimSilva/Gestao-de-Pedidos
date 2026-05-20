namespace GestaoDePedidos.Infrastructure.Configurations;

public class PedidoHistoricoStatusEntityTypeConfiguration : IEntityTypeConfiguration<PedidoHistoricoStatus>
{
    public void Configure(EntityTypeBuilder<PedidoHistoricoStatus> builder)
    {
        builder
            .ToTable("PedidoHistoricosStatus");
        
        builder
            .HasKey(phs => phs.Id);

        builder
            .Property(phs => phs.StatusAnterior)
            .IsRequired();
        
        builder
            .Property(phs => phs.StatusPosterior)
            .IsRequired();

        builder
            .Property(phs => phs.DataAlteracao)
            .IsRequired();

        builder
            .Property(phs => phs.Motivo)
            .IsRequired(false);

        builder
            .HasOne<Pedido>(phs => phs.Pedido)
            .WithMany()
            .HasForeignKey(phs => phs.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}