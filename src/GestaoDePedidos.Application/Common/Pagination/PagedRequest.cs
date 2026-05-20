namespace GestaoDePedidos.Application.Common.Pagination;

public class PagedRequest
{
    private const int TamanhoMaximoPagina = 50;

    private int _tamanhoPagina = 10;

    public int PageIndex { get; init; } = 1;

    public int PageSize
    {
        get => _tamanhoPagina;

        init => _tamanhoPagina =
            value > TamanhoMaximoPagina
                ? TamanhoMaximoPagina
                : value;
    }
}