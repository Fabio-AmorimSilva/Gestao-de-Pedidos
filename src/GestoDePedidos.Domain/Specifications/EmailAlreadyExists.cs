namespace GestoDePedidos.Domain.Specifications;

public class EmailAlreadyExists : Specification<Cliente>
{
    public EmailAlreadyExists(string email)
    {
        Query.Where(
            c => 
                c.Email == email && 
                c.Ativo
        );
    }
}