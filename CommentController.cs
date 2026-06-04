using IncidentLog.Interfaces;
using IncidentLog.DTOs.Comment;
using Microsoft.AspNetCore.Mvc;

namespace IncidentLog.Controllers;

[ApiController]
[Route("api/Incidents/{incidentId}/comments")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("{incidentId}")]
    public async Task<IActionResult> Create(Guid incidentId, CreateCommentDto dto)
    {
        var comment = await _commentService.CreateAsync(incidentId, dto);
        return Ok(comment);
    }

    [HttpGet("{incidentId}")]
    public async Task<IActionResult> GetByIncident(Guid incidentId)
    {
        var comments = await _commentService.GetByIncidentAsync(incidentId);
        return Ok(comments);
    }
}