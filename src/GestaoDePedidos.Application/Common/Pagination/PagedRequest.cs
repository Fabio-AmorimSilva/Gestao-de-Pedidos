namespace GestaoDePedidos.Application.Common.Pagination;

public record PagedRequest
{
    private const int TamanhoMaximoPagina = 50;

    private int _tamanhoPagina = 10;

    public int IndicePagina { get; init; } = 1;

    public int TamanhoPagina
    {
        get => _tamanhoPagina;

        init => _tamanhoPagina =
            value > TamanhoMaximoPagina
                ? TamanhoMaximoPagina
                : value;
    }
}