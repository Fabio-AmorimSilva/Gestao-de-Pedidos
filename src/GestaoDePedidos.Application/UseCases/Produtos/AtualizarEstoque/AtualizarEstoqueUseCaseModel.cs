namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarEstoque;

public record AtualizarEstoqueUseCaseModel(
    Guid ProdutoId,
    int Estoque
);

public class AtualizarEstoqueUseCaseModelValidator : AbstractValidator<AtualizarEstoqueUseCaseModel>
{
    public AtualizarEstoqueUseCaseModelValidator()
    {
        RuleFor(o => o.ProdutoId)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(AtualizarEstoqueUseCaseModel.ProdutoId)));

        RuleFor(o => o.Estoque)
            .Must(e => e > 0)
            .WithMessage(ErrorMessages.DeveSerMaiorQue(nameof(AtualizarEstoqueUseCaseModel.Estoque),0));
    }
}