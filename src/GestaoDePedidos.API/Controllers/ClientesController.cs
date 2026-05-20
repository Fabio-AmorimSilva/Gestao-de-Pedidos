namespace GestaoDePedidos.API.Controllers;

[Route("api/clientes")]
public class ClientesController(UseCaseValidation validation) : BaseController(validation)
{
    [HttpGet]
    public async Task<IActionResult> List()
        => await Execute<IObterClientesUseCase, Unit, Response<IEnumerable<ObterClientesUseCaseModel>>>(Unit.Value);

    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
        => await Execute<IObterClientePorIdUseCase, Guid, Response<IEnumerable<ObterClientePorIdUseCaseModel>>>(id);
    
    [HttpPut]
    public async Task<IActionResult> Deactivate(Guid id)
        => await Execute<IDesativarClienteUseCase, Guid, Response<Unit>>(id);
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CriarClienteUseCaseModel model)
        => await Execute<ICriarClienteUseCase, CriarClienteUseCaseModel, Response<Guid>>(model);
}