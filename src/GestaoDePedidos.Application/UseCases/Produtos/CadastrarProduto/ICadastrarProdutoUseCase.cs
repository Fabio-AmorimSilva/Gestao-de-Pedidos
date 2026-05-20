namespace GestaoDePedidos.Application.UseCases.Produtos.CadastrarProduto;

public interface ICadastrarProdutoUseCase
{
    Task<Response<Guid>> ExecuteAsync(CadastrarProdutoUseCaseModel dto);
}