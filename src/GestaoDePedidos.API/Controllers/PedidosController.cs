namespace GestaoDePedidos.API.Controllers;

[Route("api/pedidos")]
public class PedidosController(UseCaseValidation validation) : BaseController(validation)
{
    [HttpGet]
    [ProducesResponseType(typeof(Response<PagedResult<ObterPedidosUseCaseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> List([FromQuery] PagedRequest request)
        => await Execute<IObterPedidosUseCase, PagedRequest, Response<PagedResult<ObterPedidosUseCaseModel>>>(request);

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<ObterPedidoPorIdUseCaseModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<ObterPedidoPorIdUseCaseModel>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
        => await Execute<IObterPedidoPorIdUseCase, Guid, Response<ObterPedidoPorIdUseCaseModel>>(id);

    [HttpPost]
    [ProducesResponseType(typeof(Response<Guid>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CriarPedidoUseCaseModel model)
        => await Execute<ICriarPedidoUseCase, CriarPedidoUseCaseModel, Response<Guid>>(model);

    [HttpPatch("{id:guid}/pago")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Pago(Guid id, [FromBody] AlterarStatusDtoPayload payload)
        => await Execute<IAlterarStatusPedidoPagoUseCase, AlterarStatusDto, Response>(payload.AsDto(id));

    [HttpPatch("{id:guid}/enviado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Enviado(Guid id, [FromBody] AlterarStatusDtoPayload payload)
        => await Execute<IAlterarStatusPedidoEnviadoUseCase, AlterarStatusDto, Response>(payload.AsDto(id));

    [HttpPatch("{id:guid}/cancelado")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Cancelado(Guid id, [FromBody] AlterarStatusDtoPayload payload)
        => await Execute<IAlterarStatusPedidoParaCanceladoUseCase, AlterarStatusDto, Response>(payload.AsDto(id));

    [HttpGet("{id:guid}/historico-status")]
    [ProducesResponseType(typeof(Response<PagedResult<ObterHistoricoStatusPedidoUseCaseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> HistoricoStatus(
        Guid id,
        [FromQuery] ObterHistoricoStatusPedidoRequest request
    ) => await Execute<IObterHistoricoStatusPedidoUseCase, ObterHistoricoStatusPedidoRequest, Response<PagedResult<ObterHistoricoStatusPedidoUseCaseModel>>>(request with { PedidoId = id });

    [HttpGet("{id:guid}/historico-preco")]
    [ProducesResponseType(typeof(Response<PagedResult<ObterHistoricoPrecoUseCaseModel>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> HistoricoPreco(
        Guid id,
        [FromQuery] ObterHistoricoPrecoRequest request
    ) => await Execute<IObterHistoricoPrecoUseCase, ObterHistoricoPrecoRequest, Response<PagedResult<ObterHistoricoPrecoUseCaseModel>>>(request with { PedidoId = id });
}
