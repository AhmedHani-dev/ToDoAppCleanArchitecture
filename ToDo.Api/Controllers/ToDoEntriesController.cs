using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos.Requests;
using ToDo.Application.Dtos.Responses;
using ToDo.Application.Interfaces.Services;

namespace ToDo.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ToDoEntriesController : ControllerBase
{
    private readonly IToDoEntriesService _toDoEntriesService;

    public ToDoEntriesController(IToDoEntriesService toDoEntriesService)
    {
        _toDoEntriesService = toDoEntriesService;
    }


    [HttpGet]
    public async Task<ActionResult<GetAllToDoEntriesResponse>> ListToDoEntries()
        => await _toDoEntriesService.GetAllToDoEntries();

    [HttpPost]
    public async Task<IActionResult> InsertToDoEntry(InsertToDoEntryRequest request)
    {
        var insertedSuccessfully = await _toDoEntriesService.InsertToDoEntry(request);

        if (!insertedSuccessfully)
            return BadRequest();

        return Created();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteToDoEntry(int id)
    {
        var deletedSuccessfully = await _toDoEntriesService.DeleteToDoEntry(id);

        if (!deletedSuccessfully)
            return BadRequest();

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CloseToDoEntry(int id)
    {
        var closedSuccessfully = await _toDoEntriesService.CloseToDoEntry(id);

        if (!closedSuccessfully)
            return BadRequest();

        return Ok();
    }
}
