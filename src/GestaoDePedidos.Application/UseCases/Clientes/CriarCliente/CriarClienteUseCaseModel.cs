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
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(CriarClienteUseCaseModel.Nome)))
            .MaximumLength(Cliente.NomeTamanhoMax)
            .WithMessage(ErrorMessages.TemTamanhoMaximo(nameof(CriarClienteUseCaseModel.Nome), Cliente.NomeTamanhoMax));

        RuleFor(dto => dto.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(CriarClienteUseCaseModel.Email)))
            .EmailAddress()
            .WithMessage(ErrorMessages.EmailInvalido());

        RuleFor(dto => dto.Documento)
            .NotEmpty()
            .WithMessage(ErrorMessages.NaoPodeSerVazio(nameof(CriarClienteUseCaseModel.Documento)));
    }
}