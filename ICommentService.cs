using IncidentLog.DTOs.Comment;

namespace IncidentLog.Interfaces;

public interface ICommentService
{
    Task<CommentDto> CreateAsync(Guid incidentId, CreateCommentDto dto);

    Task<List<CommentDto>> GetByIncidentAsync(Guid incidentId);
}