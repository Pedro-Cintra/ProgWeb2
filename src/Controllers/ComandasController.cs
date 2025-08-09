
using Controllers.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shared.Dtos.Comanda;
using Shared.Dtos.ComandaItem;
using Shared.Interfaces;

namespace Controllers;

[ApiController]
[Route("[Controller]")]
public class ComandasController : APIControllerBase
{
    private readonly IServiceManager _service;

    public ComandasController(IServiceManager service, IMemoryCache cache)
    {
        _service = service;
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
        return StatusCode(StatusCodes.Status200OK, retorno);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ReadComandaProdutoDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var retorno = await _service.Comanda.GetAsync(id);
        return Ok(retorno);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(ReadComandaItemDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateComandaItemDto parameters)
    {
        var retorno = await _service.ComandaItem.CreateAsync(parameters);
        return StatusCode(StatusCodes.Status201Created, retorno);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(typeof(ReadComandaProdutoDto), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateComandaItemDto parameters)
    {
        await _service.ComandaItem.UpdateAsync(id, parameters);
        return NoContent();
    }
}
