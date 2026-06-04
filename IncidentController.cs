using IncidentLog.DTOs.Incident;
using IncidentLog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using IncidentLog.DTOs.Common;

namespace IncidentLog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var incidents = await _incidentService.GetAllAsync();
        return Ok(incidents);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var incident = await _incidentService.GetByIdAsync(id);
        if (incident == null) return NotFound();
        return Ok(incident);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateIncidentDto dto)
    {
        var createdIncident = await _incidentService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdIncident.Id }, createdIncident);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateIncidentDto dto)
    {
        var updatedIncident = await _incidentService.UpdateAsync(id, dto);
        if (updatedIncident == null) return NotFound();
        return Ok(updatedIncident);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _incidentService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] IncidentFilterDto filter)
    {
        var incidents = await _incidentService.FilterAsync(filter);
        return Ok(incidents);
    }
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] PaginationDto pagination)
    {
        var incidents = await _incidentService.GetPagedAsync(pagination);
        return Ok(incidents);
    }
}