using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.RequestFeatures;

namespace Controllers;

public class APIControllerBase : ControllerBase
{
    public OkObjectResult PagedOk<T>(PagedList<T> pagedResult)
    {
        Response.Headers.Append("X-Pagination", pagedResult.Metadata.ToString());
        return Ok(pagedResult);
    }
}
