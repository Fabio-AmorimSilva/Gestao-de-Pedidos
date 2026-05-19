namespace GestaoDePedidos.Application.Services.Clientes.Dtos;

public record CriarClienteInputDto(
    string Nome,
    string Email,
    string Documento
);

public class CriarClienteInputDtoValidator : AbstractValidator<CriarClienteInputDto>
{
    public CriarClienteInputDtoValidator()
    {
        RuleFor(dto => dto.Nome)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CriarClienteInputDto.Nome)))
            .MaximumLength(Cliente.NomeMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CriarClienteInputDto.Nome), Cliente.NomeMaxLength));

        RuleFor(dto => dto.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CriarClienteInputDto.Email)))
            .EmailAddress()
            .WithMessage(ErrorMessages.InvalidEmail());

        RuleFor(dto => dto.Documento)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CriarClienteInputDto.Documento)));
    }
}