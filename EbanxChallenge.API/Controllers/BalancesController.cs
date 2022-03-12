using EbanxChallenge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EbanxChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BalancesController : ControllerBase
{
    private readonly IAccountService _accountService;

    public BalancesController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet(Name = "GetBalance")]
    public async Task<IActionResult> Get([FromQuery]int accoundId)
    {
        var account = await _accountService.Get(accoundId);
        
        if (account == null)
            return NotFound(0);
            
        return Ok(account.GetBalance());
    }
}
