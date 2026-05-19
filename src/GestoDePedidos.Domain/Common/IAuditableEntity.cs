namespace GestoDePedidos.Domain.Common;

public interface IAuditableEntity
{
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}