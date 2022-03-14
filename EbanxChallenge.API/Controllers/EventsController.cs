using EbanxChallenge.Domain.DTOs;
using EbanxChallenge.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EbanxChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost(Name = "RegisterEvent")]
    [Produces(typeof(EventOutputDTO))]
    public async Task<IActionResult> RegisterEvent([FromBody]EventInputDTO eventDto)
    {
        EventOutputDTO eventOutput = await _eventService.Execute(eventDto);
        if (eventOutput == null)
            return NotFound(0);

        return Ok("OK");
    }
}
