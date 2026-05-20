namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarProduto;

public record AtualizarProdutoUseCaseModel(
    Guid ProdutoId,
    string Nome,
    string Descricao,
    decimal Preco
);

public class AtualizarProdutoUseCaseModelValidator : AbstractValidator<AtualizarProdutoUseCaseModel>
{
    public AtualizarProdutoUseCaseModelValidator()
    {
        RuleFor(m => m.ProdutoId)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(AtualizarProdutoUseCaseModel.ProdutoId)));

        RuleFor(m => m.Nome)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(AtualizarProdutoUseCaseModel.Nome)))
            .MaximumLength(Produto.NomeMaxLength)
            .WithMessage(ErrorMessages.TemTamanhoMaximo(nameof(AtualizarProdutoUseCaseModel.Nome), Produto.NomeMaxLength));
        
        RuleFor(m => m.Descricao)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(AtualizarProdutoUseCaseModel.Nome)))
            .MaximumLength(Produto.DescricaoMaxLength)
            .WithMessage(ErrorMessages.TemTamanhoMaximo(nameof(AtualizarProdutoUseCaseModel.Descricao), Produto.DescricaoMaxLength));
        
        RuleFor(m => m.Preco)
            .Must(m => m > 0)
            .WithMessage(ErrorMessages.DeveSerMaiorQue(nameof(AtualizarProdutoUseCaseModel.Preco),0));
    }
}