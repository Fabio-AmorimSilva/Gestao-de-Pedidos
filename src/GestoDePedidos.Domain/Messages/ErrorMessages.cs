namespace GestoDePedidos.Domain.Messages;

public static class ErrorMessages
{
    public static string NaoPodeSerVazio(string campo)
        => $"{campo} não pode ser vazio";

    public static string TemTamanhoMaximo(string campo, int tamanho)
        => $"{campo} deve ter o tamanho máximo de {tamanho} caracteres";
    
    public static string DeveSerMaiorQue(string campo, int valor)
        => $"{campo} deve mairo que {valor}";

    public static string NaoEncontrado(string campo)
        => $"{campo} não pode ser encontrado";
    
    public static string NaoEncontrado<T>()
        => $"{typeof(T).Name} não pode ser encontrado";
    
    public static string DeveSerUnico(string campo)
        => $"{campo} deve ser único";

    public static string EmailInvalido()
        => "O Email é inválido";
    
    public static string EstoqueInsuficiente()
        => "Estoque insuficiente";
}