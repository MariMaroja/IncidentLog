using IncidentLog.Data;
using IncidentLog.DTOs.Comment;
using IncidentLog.Interfaces;
using IncidentLog.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentLog.Services;

public class CommentService : ICommentService
{
    private readonly AppDbContext _context;

    public CommentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CommentDto> CreateAsync(
        Guid incidentId,
        CreateCommentDto dto)
    {
        var comment = new Comment
        {
            IncidentId = incidentId,
            Content = dto.Content
        };

        _context.Comments.Add(comment);

        await _context.SaveChangesAsync();

        return new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedAt = comment.CreatedAt
        };
    }

    public async Task<List<CommentDto>>
        GetByIncidentAsync(Guid incidentId)
    {
        return await _context.Comments
            .Where(c => c.IncidentId == incidentId)
            .Select(c => new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync();
    }
}