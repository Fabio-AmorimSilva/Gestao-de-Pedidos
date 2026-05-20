namespace GestaoDePedidos.Application.UseCases.Pedidos.Dtos;

public record AlterarStatusDto(
    Guid PedidoId,
    string? Motivo
);

public class AlterarStatusValidator : AbstractValidator<AlterarStatusDto>
{
    public AlterarStatusValidator()
    {
        RuleFor(m => m.PedidoId)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(AlterarStatusDto.PedidoId)));
        
        RuleFor(m => m.Motivo)
            .MaximumLength(PedidoHistoricoStatus.MotivoMaxLength)
            .When(m => !string.IsNullOrEmpty(m.Motivo))
            .WithMessage(ErrorMessages.TemTamanhoMaximo(nameof(AlterarStatusDto.Motivo), PedidoHistoricoStatus.MotivoMaxLength));
    }
}