namespace GestaoDePedidos.Application.UseCases.Produtos.CadastrarProduto;

public record CadastrarProdutoUseCaseModel(
    string Nome,
    string Descricao,
    decimal Preco,
    int Estoque
);

public class CadastrarProdutoUseCaseModelValidator : AbstractValidator<CadastrarProdutoUseCaseModel>
{
    public CadastrarProdutoUseCaseModelValidator()
    {
        RuleFor(m => m.Nome)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(CadastrarProdutoUseCaseModel.Nome)))
            .MaximumLength(Produto.NomeTamanhoMaximo)
            .WithMessage(ErrorMessages.TemTamanhoMaximo(nameof(CadastrarProdutoUseCaseModel.Nome), Produto.NomeTamanhoMaximo));
        
        RuleFor(m => m.Descricao)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(CadastrarProdutoUseCaseModel.Nome)))
            .MaximumLength(Produto.DescricaoTamanhoMaximo)
            .WithMessage(ErrorMessages.TemTamanhoMaximo(nameof(CadastrarProdutoUseCaseModel.Descricao), Produto.DescricaoTamanhoMaximo));
        
        RuleFor(m => m.Preco)
            .Must(m => m > 0)
            .WithMessage(ErrorMessages.DeveSerMaiorQue(nameof(CadastrarProdutoUseCaseModel.Preco),0));
    }
}