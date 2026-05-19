namespace GestaoDePedidos.Application.Responses;

public class CreatedResponse<T> : ApiResponse<T>
{
    public CreatedResponse(T data)
    {
        StatusCode = 201;
        IsSuccess = true;
        Data = data;
    }
}