namespace GestaoDePedidos.Application.UseCases.Pedidos.CriarPedido;

public record CriarPedidoUseCaseModel(
    Guid ClienteId,
    IEnumerable<CriarPedidoItemUseCaseModel> Itens
);

public class CriarPedidoUseCaseModelValidator : AbstractValidator<CriarPedidoUseCaseModel>
{
    public CriarPedidoUseCaseModelValidator()
    {
        RuleFor(o => o.ClienteId)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(CriarPedidoUseCaseModel.ClienteId)));
        
        RuleForEach(o => o.Itens)
            .SetValidator(new CriarPedidoItemUseCaseModelValidator());
    }
}
