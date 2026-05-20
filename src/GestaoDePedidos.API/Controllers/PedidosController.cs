namespace GestaoDePedidos.API.Controllers;

[Route("api/pedidos")]
public class PedidosController(UseCaseValidation validation) : BaseController(validation)
{
    [HttpGet]
    public async Task<IActionResult> List([FromQuery] PagedRequest request)
        => await Execute<IObterPedidosUseCase, PagedRequest, Response<PagedResult<ObterPedidosUseCaseModel>>>(request);

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
        => await Execute<IObterPedidoPorIdUseCase, Guid, Response<ObterPedidoPorIdUseCaseModel>>(id);

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriarPedidoUseCaseModel model)
        => await Execute<ICriarPedidoUseCase, CriarPedidoUseCaseModel, Response<Guid>>(model);

    [HttpPatch("{id:guid}/pago")]
    public async Task<IActionResult> Pago(Guid id, [FromBody] AlterarStatusDtoPayload payload)
        => await Execute<IAlterarStatusPedidoPagoUseCase, AlterarStatusDto, Response>(payload.AsDto(id));

    [HttpPatch("{id:guid}/enviado")]
    public async Task<IActionResult> Enviado(Guid id, [FromBody] AlterarStatusDtoPayload payload)
        => await Execute<IAlterarStatusPedidoEnviadoUseCase, AlterarStatusDto, Response>(payload.AsDto(id));

    [HttpPatch("{id:guid}/cancelado")]
    public async Task<IActionResult> Cancelado(Guid id, [FromBody] AlterarStatusDtoPayload payload)
        => await Execute<IAlterarStatusPedidoParaCanceladoUseCase, AlterarStatusDto, Response>(payload.AsDto(id));

    [HttpGet("{id:guid}/historico-status")]
    public async Task<IActionResult> HistoricoStatus(
        Guid id, 
        [FromQuery] ObterHistoricoStatusPedidoRequest request
    ) => await Execute<IObterHistoricoStatusPedidoUseCase, ObterHistoricoStatusPedidoRequest, Response<PagedResult<ObterHistoricoStatusPedidoUseCaseModel>>>(request with { PedidoId = id });
}