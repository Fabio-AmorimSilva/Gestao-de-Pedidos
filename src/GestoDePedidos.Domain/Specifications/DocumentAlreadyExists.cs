namespace GestoDePedidos.Domain.Specifications;

public class DocumentAlreadyExists : Specification<Cliente>
{
    public DocumentAlreadyExists(string documento)
    {
        Query.Where(c =>
            c.Documento == documento &&
            c.Ativo
        );
    }
}