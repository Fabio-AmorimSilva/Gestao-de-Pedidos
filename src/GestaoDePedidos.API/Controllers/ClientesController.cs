namespace GestaoDePedidos.API.Controllers;

[Route("api/clientes")]
public class ClientesController(UseCaseValidation validation) : BaseController(validation)
{
    [HttpGet]
    [ProducesResponseType(typeof(Response<PagedResult<ObterClientesUseCaseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> List([FromQuery] PagedRequest request)
        => await Execute<IObterClientesUseCase, PagedRequest, Response<PagedResult<ObterClientesUseCaseModel>>>(request);

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(typeof(Response<ObterClientePorIdUseCaseModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<ObterClientePorIdUseCaseModel>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response<ObterClientePorIdUseCaseModel>), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Get(Guid id)
        => await Execute<IObterClientePorIdUseCase, Guid, Response<ObterClientePorIdUseCaseModel>>(id);

    [HttpPatch("{id:guid}/deactivate")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Response<Unit>), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(Response<Unit>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Deactivate(Guid id)
        => await Execute<IDesativarClienteUseCase, Guid, Response<Unit>>(id);

    [HttpPost]
    [ProducesResponseType(typeof(Response<CriarClienteUseCaseModel>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Response<CriarClienteUseCaseModel>), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CriarClienteUseCaseModel model)
        => await Execute<ICriarClienteUseCase, CriarClienteUseCaseModel, Response<Guid>>(model);
}