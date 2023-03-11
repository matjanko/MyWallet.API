using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Debts.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    /// <summary>
    /// Creates a Loan.
    /// </summary>
    /// <returns></returns>
    /// <response code="201">Returns the newly created loan</response>
    /// <response code="400">Bad Request</response>
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostAsync()
    {
        return Ok();
    }
}