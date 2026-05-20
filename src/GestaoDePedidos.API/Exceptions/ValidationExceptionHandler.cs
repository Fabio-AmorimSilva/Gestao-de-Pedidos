namespace GestaoDePedidos.API.Exceptions;

public class ValidationExceptionHandler(
    IProblemDetailsService problemDetailsService,
    ILogger<ValidationExceptionHandler> logger
) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception, 
        CancellationToken cancellationToken
    )
    {
        if (exception is not ValidationException validationException)
            return false;
            
        logger.LogInformation(exception, exception.Message);

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Detail = "One or more validation errors occurred.",
                Status = StatusCodes.Status422UnprocessableEntity,
                Title = "Validation Error",
                Type = exception.GetType().Name
            }
        };

        var errors = validationException.Errors
            .GroupBy(ve => ve.PropertyName)
            .ToDictionary(
                g => g.Key.ToLowerInvariant(),
                g => g.Select(e => e.ErrorMessage).ToArray()
            );
        
        context.ProblemDetails.Extensions.TryAdd("errors", errors);
        
        return await problemDetailsService.TryWriteAsync(context);
    }
}