namespace GestaoDePedidos.Application.UseCases.Produtos.AtualizarEstoque;

public interface IAtualizarEstoqueUseCase
{
    Task<Response> ExecuteAsync(AtualizarEstoqueUseCaseModel model);
}