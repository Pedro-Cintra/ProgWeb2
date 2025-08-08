
using Controllers.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shared.Dtos.Usuario;
using Shared.Interfaces;

namespace Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController: APIControllerBase
{
    private readonly IServiceManager _service;

    public UsuarioController(IServiceManager service)
    {
        _service = service;       
    }    

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(typeof(ReadUsuarioDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateUsuarioDto parameters)
    {
        var retorno = await _service.Usuario.CreateAsync(parameters);
        return Ok(retorno);
    }
}
