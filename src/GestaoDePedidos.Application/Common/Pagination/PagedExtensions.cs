namespace GestaoDePedidos.Application.Common.Pagination;

public static class PaginationExtensions
{
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
        this IQueryable<T> query,
        PagedRequest request
    )
    {
        var indicePagina = Math.Max(request.IndicePagina, 1);
        var tamanhoPagina = Math.Max(request.TamanhoPagina, 1);

        var totalRecords =
            await query.CountAsync();

        var dados = await query
            .Skip((indicePagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToListAsync();

        return new PagedResult<T>
        {
            Dados = dados,
            IndicePagina = indicePagina,
            TamanhoPagina = tamanhoPagina,
            TotalRegistros = totalRecords,
            TotalPaginas = (int)Math.Ceiling(totalRecords / (double)tamanhoPagina)
        };
    }
}