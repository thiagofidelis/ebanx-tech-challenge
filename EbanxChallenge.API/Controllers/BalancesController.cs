using Microsoft.AspNetCore.Mvc;

namespace EbanxChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BalancesController : ControllerBase
{

    public BalancesController()
    {
        
    }

    [HttpGet(Name = "GetBalance")]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }
}
