namespace GestaoDePedidos.Application.UseCases.Produtos.DesativarProduto;

public interface IDesativarProdutoUseCase
{
    Task<Response> ExecuteAsync(Guid id);
}