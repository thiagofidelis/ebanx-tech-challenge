using EbanxChallenge.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace EbanxChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ResetController : ControllerBase
{
    private readonly IAccountService _accountService;

    public ResetController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost(Name = "Reset")]
    [Produces("text/plain")]
    public async Task<string> Reset()
    {
        await _accountService.Reset();
            
        return "OK";
    }

    
}
