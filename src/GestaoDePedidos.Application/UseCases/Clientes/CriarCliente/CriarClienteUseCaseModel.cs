namespace GestaoDePedidos.Application.UseCases.Clientes.CriarCliente;

public record CriarClienteUseCaseModel(
    string Nome,
    string Email,
    string Documento
);

public class CriarClienteUseCaseModelValidator : AbstractValidator<CriarClienteUseCaseModel>
{
    public CriarClienteUseCaseModelValidator()
    {
        RuleFor(dto => dto.Nome)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CriarClienteUseCaseModel.Nome)))
            .MaximumLength(Cliente.NomeMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CriarClienteUseCaseModel.Nome), Cliente.NomeMaxLength));

        RuleFor(dto => dto.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CriarClienteUseCaseModel.Email)))
            .EmailAddress()
            .WithMessage(ErrorMessages.InvalidEmail());

        RuleFor(dto => dto.Documento)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CriarClienteUseCaseModel.Documento)));
    }
}