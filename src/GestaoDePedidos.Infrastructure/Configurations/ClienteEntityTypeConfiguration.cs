namespace GestaoDePedidos.Infrastructure.Configurations;

public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder
            .ToTable("Clientes");
        
        builder
            .HasKey(c => c.Id);

        builder
            .HasIndex(c => c.Documento);

        builder
            .Property(c => c.Nome)
            .HasMaxLength(Cliente.NomeMaxLength)
            .IsRequired();

        builder
            .Property(c => c.Email)
            .IsRequired();
        
        builder
            .Property(c => c.Documento)
            .IsRequired();
        
        builder
            .Property(c => c.Ativo)
            .IsRequired();
        
        builder
            .Property(c => c.DataCriacao)
            .IsRequired();
        
        builder
            .Property(c => c.DataAtualizacao)
            .IsRequired(false);
    }
}