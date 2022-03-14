using EbanxChallenge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EbanxChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ResetsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public ResetsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet(Name = "Reset")]
    public async Task<IActionResult> Reset([FromQuery]int accoundId)
    {
        await _accountService.Reset();
            
        return Ok("OK");
    }
}
