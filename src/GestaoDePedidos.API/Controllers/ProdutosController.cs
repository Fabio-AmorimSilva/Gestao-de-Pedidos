namespace GestaoDePedidos.API.Controllers;

[Route("api/produtos")]
public class ProdutosController(UseCaseValidation validation) : BaseController(validation)
{
    [HttpGet]
    public async Task<IActionResult> List([FromQuery] PagedRequest request)
        => await Execute<IObterProdutosUseCase, PagedRequest, Response<PagedResult<ObterProdutosUseCaseModel>>>(request);

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
        => await Execute<IObterProdutoPorIdUseCase, Guid, Response<ObterProdutoPorIdUseCaseModel>>(id);

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CadastrarProdutoUseCaseModel model)
        => await Execute<ICadastrarProdutoUseCase, CadastrarProdutoUseCaseModel, Response<Guid>>(model);

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarProdutoUseCaseModelPayload payload)
        => await Execute<IAtualizarProdutoUseCase, AtualizarProdutoUseCaseModel, Response>(payload.AsModel(id));

    [HttpPatch("{id:guid}/estoque")]
    public async Task<IActionResult> AtualizarEstoque(Guid id, [FromBody] AtualizarEstoqueUseCaseModelPayload payload)
        => await Execute<IAtualizarEstoqueUseCase, AtualizarEstoqueUseCaseModel, Response>(payload.AsDto(id));

    [HttpPatch("{id:guid}/ativar")]
    public async Task<IActionResult> Ativar(Guid id)
        => await Execute<IAtivarProdutoUseCase, Guid, Response>(id);

    [HttpPatch("{id:guid}/desativar")]
    public async Task<IActionResult> Desativar(Guid id)
        => await Execute<IDesativarProdutoUseCase, Guid, Response>(id);
}
