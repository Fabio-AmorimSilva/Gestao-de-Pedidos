namespace GestoDePedidos.Domain.Messages;

public static class ErrorMessages
{
    public static string NaoPodeSerVazio(string field)
        => $"{field} não pode ser vazio";

    public static string TemTamanhoMaximo(string field, int length)
        => $"{field} deve ter o tamanho máximo de {length} caracteres";

    public static string NaoEncontrado(string field)
        => $"{field} não pode ser encontrado";
    
    public static string NaoEncontrado<T>()
        => $"{typeof(T).Name} não pode ser encontrado";
    
    public static string DeveSerUnico(string field)
        => $"{field} deve ser único";

    public static string EmailInvalido()
        => "O Email é inválido";
    
    public static string EstoqueInsuficiente()
        => "Estoque insuficiente";
}