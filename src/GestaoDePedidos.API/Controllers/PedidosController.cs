namespace GestaoDePedidos.API.Controllers;

[Route("api/pedidos")]
public class PedidosController(UseCaseValidation validation) : BaseController(validation)
{
    [HttpGet]
    public async Task<IActionResult> List()
        => await Execute<IObterPedidosUseCase, Unit, Response<IEnumerable<ObterPedidosUseCaseModel>>>(Unit.Value);

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
        => await Execute<IObterPedidoPorIdUseCase, Guid, Response<ObterPedidoPorIdUseCaseModel>>(id);

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriarPedidoUseCaseModel model)
        => await Execute<ICriarPedidoUseCase, CriarPedidoUseCaseModel, Response<Guid>>(model);

    [HttpPut("{id:guid}/pago")]
    public async Task<IActionResult> Pago(Guid id)
        => await Execute<IAlterarStatusPedidoPagoUseCase, Guid, Response>(id);

    [HttpPut("{id:guid}/enviado")]
    public async Task<IActionResult> Enviado(Guid id)
        => await Execute<IAlterarStatusPedidoEnviadoUseCase, Guid, Response>(id);

    [HttpPut("{id:guid}/cancelado")]
    public async Task<IActionResult> Cancelado(Guid id)
        => await Execute<IAlterarStatusPedidoParaCanceladoUseCase, Guid, Response>(id);

    [HttpGet("{id:guid}/historico-status")]
    public async Task<IActionResult> HistoricoStatus(Guid id)
        => await Execute<IObterHistoricoStatusPedidoUseCase, Guid, Response<IEnumerable<ObterHistoricoStatusPedidoUseCaseModel>>>(id);
}