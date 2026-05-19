namespace GestoDePedidos.Domain.Entities;

public class Cliente : Entity, IAuditableEntity
{
    public const int NomeMaxLength = 200; 
    
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Documento { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }

    public Cliente(
        string nome,
        string email,
        string documento
    )
    {
        Guard.IsNotEmpty(nome);
        Guard.IsNotEmpty(email);
        Guard.IsNotEmpty(documento);
        
        Nome = nome;
        Email = email;
        Documento = documento;
        Ativo = true;
    }

    public void Desativar()
    {
        Ativo = false;
    }
}