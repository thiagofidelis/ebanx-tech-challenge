using System.Net;
using EbanxChallenge.Domain.DTOs;
using EbanxChallenge.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace EbanxChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost(Name = "RegisterEvent")]
    public async Task<IActionResult> RegisterEvent([FromBody]EventInputDTO eventDto)
    {
        var eventOutput = await _eventService.Execute(eventDto);

        // event from non existing account
        if (eventOutput == null)
            return NotFound(0);

        return StatusCode(StatusCodes.Status201Created, eventOutput);
    }
}
