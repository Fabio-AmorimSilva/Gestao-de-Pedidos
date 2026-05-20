namespace GestaoDePedidos.API.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    private readonly UseCaseValidation _validation;

    protected BaseController(UseCaseValidation validation)
    {
        _validation = validation;
    }

    protected async Task<IActionResult> Execute<TUseCase, TRequest, TResponse>(TRequest request)
        where TUseCase : class
    {
        var result = await _validation.Execute<TUseCase, TRequest, TResponse>(request);

        return MapResponse((dynamic)result!);
    }
    
    private IActionResult MapResponse(Response? result)
        => result switch
        {
            NoContentResponse => NoContent(),
            { IsSuccess: false } => NotFound(new ProblemDetails
            {
                Title = "Resource not found",
                Detail = result.Message,
                Status = 404
            }),
            _ => Problem(title: "Unexpected error", statusCode: 500)
        };

    private IActionResult MapResponse<T>(Response<T>? result)
        => result switch
        {
            OkResponse<T> ok => Ok(ok.Data),

            CreatedResponse<T> created => Created(
                string.Empty,
                created.Data),

            NotFoundResponse<T> notFound => NotFound(
                new ProblemDetails
                {
                    Title = "Resource not found",
                    Detail = notFound.Message,
                    Status = 404
                }),

            UnprocessableResponse<T> unprocessable => UnprocessableEntity(
                new ProblemDetails
                {
                    Title = "Validation error",
                    Detail = unprocessable.Message,
                    Status = 422
                }),

            NoContentResponse => NoContent(),
            _ => Problem(
                title: "Unexpected error",
                statusCode: 500)
        };
}