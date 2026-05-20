namespace GestaoDePedidos.Application.Common.Pagination;

public sealed class PagedResult<T>
{
    public IReadOnlyCollection<T> Dados { get; init; } = [];

    public int IndicePagina { get; init; }

    public int TamanhoPagina { get; init; }

    public int TotalRegistros { get; init; }

    public int TotalPaginas { get; init; }

    public bool TemProximaPagina => IndicePagina < TotalPaginas;

    public bool TemPaginaAnterior => IndicePagina > 1;
}