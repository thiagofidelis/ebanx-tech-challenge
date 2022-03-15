using EbanxChallenge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EbanxChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BalanceController : ControllerBase
{
    private readonly IAccountService _accountService;

    public BalanceController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet(Name = "GetBalance")]
    public async Task<IActionResult> Get([FromQuery]string account_id)
    {
        decimal? balance = await _accountService.GetBalance(account_id);
        
        if (balance == null)
            return NotFound(0);
            
        return Ok(balance);
    }
}
