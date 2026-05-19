namespace GestaoDePedidos.Application.Responses;

public class NotFoundResponse<T>  : ApiResponse<T>
{
    public NotFoundResponse(string message)
    {
        StatusCode = 404;
        IsSuccess = false;
        Message = message;
    }
}