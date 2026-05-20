namespace GestaoDePedidos.API.Controllers;

[Route("api/clientes")]
public class ClientesController(UseCaseValidation validation) : BaseController(validation)
{
    [HttpGet]
    public async Task<IActionResult> List([FromQuery]  PagedRequest request)
        => await Execute<IObterClientesUseCase, PagedRequest, Response<PagedResult<ObterClientesUseCaseModel>>>(request);

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
        => await Execute<IObterClientePorIdUseCase, Guid, Response<ObterClientePorIdUseCaseModel>>(id);
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Deactivate(Guid id)
        => await Execute<IDesativarClienteUseCase, Guid, Response<Unit>>(id);
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriarClienteUseCaseModel model)
        => await Execute<ICriarClienteUseCase, CriarClienteUseCaseModel, Response<Guid>>(model);
}