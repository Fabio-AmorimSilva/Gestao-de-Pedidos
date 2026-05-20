namespace GestaoDePedidos.Infrastructure.Configurations;

public class ProdutoEntityTypeConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder
            .ToTable("Produtos");

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Nome)
            .HasMaxLength(Produto.NomeTamanhoMaximo)
            .IsRequired();

        builder
            .Property(p => p.Descricao)
            .HasMaxLength(Produto.DescricaoTamanhoMaximo)
            .IsRequired();

        builder
            .Property(p => p.Preco)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(p => p.Estoque)
            .IsRequired();

        builder
            .Property(p => p.Ativo)
            .IsRequired();

        builder
            .Property(p => p.DataCriacao)
            .IsRequired();

        builder
            .Property(p => p.DataAtualizacao)
            .IsRequired(false);
    }
}
