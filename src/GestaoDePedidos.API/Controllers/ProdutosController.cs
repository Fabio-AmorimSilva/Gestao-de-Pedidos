namespace GestaoDePedidos.API.Controllers;

[Route("api/produtos")]
public class ProdutosController(UseCaseValidation validation) : BaseController(validation)
{
    [HttpGet]
    [ProducesResponseType(typeof(Response<PagedResult<ObterProdutosUseCaseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> List([FromQuery] PagedRequest request)
        => await Execute<IObterProdutosUseCase, PagedRequest, Response<PagedResult<ObterProdutosUseCaseModel>>>(request);

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<ObterProdutoPorIdUseCaseModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
        => await Execute<IObterProdutoPorIdUseCase, Guid, Response<ObterProdutoPorIdUseCaseModel>>(id);

    [HttpPost]
    [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CadastrarProdutoUseCaseModel model)
        => await Execute<ICadastrarProdutoUseCase, CadastrarProdutoUseCaseModel, Response<Guid>>(model);

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Put(Guid id, [FromBody] AtualizarProdutoUseCaseModelPayload payload)
        => await Execute<IAtualizarProdutoUseCase, AtualizarProdutoUseCaseModel, Response>(payload.AsModel(id));

    [HttpPatch("{id:guid}/estoque")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> AtualizarEstoque(Guid id, [FromBody] AtualizarEstoqueUseCaseModelPayload payload)
        => await Execute<IAtualizarEstoqueUseCase, AtualizarEstoqueUseCaseModel, Response>(payload.AsDto(id));

    [HttpPatch("{id:guid}/ativar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Ativar(Guid id)
        => await Execute<IAtivarProdutoUseCase, Guid, Response>(id);

    [HttpPatch("{id:guid}/desativar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Desativar(Guid id)
        => await Execute<IDesativarProdutoUseCase, Guid, Response>(id);
}
