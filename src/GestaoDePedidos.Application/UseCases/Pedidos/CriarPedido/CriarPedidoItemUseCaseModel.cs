namespace GestaoDePedidos.Application.UseCases.Pedidos.CriarPedido;

public record CriarPedidoItemUseCaseModel(
    Guid ProdutoId,
    int Quantidade
);

public class CriarPedidoItemUseCaseModelValidator : AbstractValidator<CriarPedidoItemUseCaseModel>
{
    public CriarPedidoItemUseCaseModelValidator()
    {
        RuleFor(o => o.ProdutoId)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(CriarPedidoItemUseCaseModel.ProdutoId)));
        
        RuleFor(o => o.Quantidade)
            .GreaterThan(0)
            .WithMessage(ErrorMessages.DeveSerMaiorQue(nameof(CriarPedidoItemUseCaseModel.Quantidade), 0));
    }
}