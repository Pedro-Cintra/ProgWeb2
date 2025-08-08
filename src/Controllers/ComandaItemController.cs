
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
public class ComandaItemController : APIControllerBase
{
    private readonly IServiceManager _service;

    public ComandaItemController(IServiceManager service, IMemoryCache cache)
    {
        _service = service;
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(ReadComandaItemDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateComandaItemDto parameters)
    {
        var retorno = await _service.ComandaItem.CreateAsync(parameters);
        return Ok(retorno);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ReadComandaProdutoDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int id)
    {
        var retorno = await _service.ComandaItem.GetAsync(id);
        return Ok(retorno);
    }
}
