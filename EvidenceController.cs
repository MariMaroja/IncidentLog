using IncidentLog.DTOs.Evidence;
using IncidentLog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IncidentLog.Controllers;

[ApiController]
[Route("api/incidents/{incidentId}/evidences")]
public class EvidenceController : ControllerBase
{
    private readonly IEvidenceService _evidenceService;

    public EvidenceController(IEvidenceService evidenceService)
    {
        _evidenceService = evidenceService;
    }

    [HttpGet]
    public async Task<IActionResult>
        GetAll(Guid incidentId)
    {
        var evidences = await _evidenceService.GetByIncidentAsync(incidentId);
        return Ok(evidences);
    }

    [HttpPost]
    public async Task<IActionResult>Create(Guid incidentId,CreateEvidenceDto dto)
    {
        var evidence = await _evidenceService.CreateAsync(incidentId, dto);

        return Ok(evidence);
    }
}