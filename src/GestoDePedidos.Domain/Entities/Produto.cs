namespace GestoDePedidos.Domain.Entities;

public class Produto : Entity, IAuditableEntity
{
    public const int NomeMaxLength = 500;
    public const int DescricaoMaxLength = 2000;

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }

    public Produto(
        string nome,
        string descricao,
        decimal preco,
        int estoque
    )
    {
        Guard.IsNotEmpty(nome);
        Guard.IsGreaterThan(estoque, 0);

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Estoque = estoque;
        Ativo = true;
    }

    public void AtualizarDados(string nome, string descricao, decimal preco)
    {
        Guard.IsNotEmpty(nome);

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }

    public void AdicionarAoEstoque(int estoque)
    {
        Guard.IsGreaterThan(estoque, 0);
        Estoque += estoque;
    }

    public void AtualizarEstoque(int estoque)
    {
        Guard.IsGreaterThan(estoque, 0);
        Estoque = estoque;
    }

    public bool RemoverEstoque(int estoque)
    {
        Guard.IsGreaterThan(estoque, 0);

        if (Estoque < estoque)
            return false;
        
        Estoque -= estoque;

        return true;
    }

    public void Ativar() => Ativo = true;

    public void Desativar() => Ativo = false;
}