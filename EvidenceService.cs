using IncidentLog.Data;
using IncidentLog.DTOs.Evidence;
using IncidentLog.Interfaces;
using IncidentLog.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentLog.Services;

public class EvidenceService : IEvidenceService
{
    private readonly AppDbContext _context;

    public EvidenceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EvidenceDto>CreateAsync(Guid incidentId,CreateEvidenceDto dto)
    {
        var evidence = new Evidence
        {
            IncidentId = incidentId,
            FileUrl = dto.FileUrl,
            Description = dto.Description
        };

        _context.Evidences.Add(evidence);

        await _context.SaveChangesAsync();

        return new EvidenceDto
        {
            Id = evidence.Id,
            FileUrl = evidence.FileUrl,
            Description = evidence.Description,
            CreatedAt = evidence.CreatedAt
        };
    }

    public async Task<List<EvidenceDto>>
        GetByIncidentAsync(
            Guid incidentId)
    {
        return await _context.Evidences.Where(e => e.IncidentId == incidentId).Select(e => new EvidenceDto {Id = e.Id, FileUrl = e.FileUrl, Description = e.Description, CreatedAt = e.CreatedAt}).ToListAsync();
    }
}