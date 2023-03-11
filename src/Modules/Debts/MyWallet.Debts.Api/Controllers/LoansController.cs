using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MyWallet.Debts.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Creates a Loan")]
    [SwaggerResponse(StatusCodes.Status201Created, "Returns the newly created loan")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request")]
    public async Task<IActionResult> PostAsync()
    {
        return Ok();
    }
}