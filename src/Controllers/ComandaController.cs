
using Controllers.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shared.Dtos.Comanda;
using Shared.Interfaces;

namespace Controllers;

[ApiController]
[Route("[Controller]")]
public class ComandaController : APIControllerBase
{
    private readonly IServiceManager _service;

    public ComandaController(IServiceManager service, IMemoryCache cache)
    {
        _service = service;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(ReadComandaDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateComandaDto parameters)
    {
        var retorno = await _service.Comanda.CreateAsync(parameters);
        return StatusCode(StatusCodes.Status201Created, retorno);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ReadComandaDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var retorno = await _service.Comanda.GetAllAsync();
        return Ok(retorno);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(IEnumerable<ReadComandaDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var retorno = await _service.Comanda.DeleteAsync(id);
        //TODO Ver qual código de status é o mais adequado
        return StatusCode(StatusCodes.Status200OK, retorno);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ReadComandaProdutoDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var retorno = await _service.Comanda.GetAsync(id);
        return Ok(retorno);
    }
}
