using Microsoft.AspNetCore.Mvc;

namespace MyWallet.Expenses.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillsController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> GetAsync()
    {
        throw new NotImplementedException();
    }
}