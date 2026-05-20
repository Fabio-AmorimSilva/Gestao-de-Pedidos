namespace GestaoDePedidos.Application.Behaviours;

public class UseCaseValidation(IServiceProvider serviceProvider)
{
    public async Task<TResponse> Execute<TUseCase, TRequest, TResponse>(TRequest request)
    {
        var validators = serviceProvider.GetServices<IValidator<TRequest>>();

        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var results = await Task.WhenAll(
                validators.Select(v => v.ValidateAsync(context))
            );

            var errors = results
                .SelectMany(e => e.Errors)
                .Where(f => f != null)
                .ToList();

            if (errors.Any())
                throw new ValidationException(errors);
        }

        var useCase = serviceProvider.GetRequiredService<TUseCase>();

        var method = typeof(TUseCase).GetMethod("ExecuteAsync");

        if (method is null)
            throw new Exception("UseCase does not have ExecuteAsync method");

        var parameters = method.GetParameters();

        var result = method.Invoke(useCase, parameters.Length == 0 ? null : new object[] { request });

        return await (Task<TResponse>)result!;
    }
}