using IncidentLog.Data;
using IncidentLog.DTOs.Incident;
using IncidentLog.Interfaces;
using IncidentLog.Models;
using Microsoft.EntityFrameworkCore;
using IncidentLog.DTOs.Common;

namespace IncidentLog.Services;

public class IncidentService : IIncidentService
{
    private readonly AppDbContext _context;

    public IncidentService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<IncidentDto>> GetAllAsync()
    {
        return await _context.Incidents.Select(i => new IncidentDto{
            Id = i.Id,
            Title = i.Title,
            Description = i.Description,
            Category = i.Category,
            Severity = i.Severity,
            Status = i.Status,
            CreatedAt = i.CreatedAt,
        }).ToListAsync();
    }
    public async Task<IncidentDto?> GetByIdAsync(Guid id)
    {
        var incident = await _context.Incidents.FirstOrDefaultAsync(i => i.Id == id);
        if (incident == null) return null;
        return new IncidentDto
        {
            Id = incident.Id,
            Title = incident.Title,
            Description = incident.Description,
            Category = incident.Category,
            Severity = incident.Severity,
            Status = incident.Status,
            CreatedAt = incident.CreatedAt,
        };
    }
    public async Task<IncidentDto> CreateAsync(CreateIncidentDto dto)
    {
        var incident = new IncidentLog.Models.Incident
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            Category = dto.Category,
            Severity = dto.Severity,
            Status = Enums.IncidentStatus.Open,
            CreatedAt = DateTime.UtcNow
        };
        _context.Incidents.Add(incident);
        await _context.SaveChangesAsync();
        return new IncidentDto
        {
            Id = incident.Id,
            Title = incident.Title,
            Description = incident.Description,
            Category = incident.Category,
            Severity = incident.Severity,
            Status = incident.Status,
            CreatedAt = incident.CreatedAt,
        };
    }
    public async Task<IncidentDto?> UpdateAsync(Guid id, UpdateIncidentDto dto)
    {
        var incident = await _context.Incidents.FirstOrDefaultAsync(i => i.Id == id);
        if (incident == null) return null;
        incident.Title = dto.Title;
        incident.Description = dto.Description;
        incident.Category = dto.Category;
        incident.Severity = dto.Severity;
        incident.Status = dto.Status;
        await _context.SaveChangesAsync();
        return new IncidentDto
        {
            Id = incident.Id,
            Title = incident.Title,
            Description = incident.Description,
            Category = incident.Category,
            Severity = incident.Severity,
            Status = incident.Status,
            CreatedAt = incident.CreatedAt,
        };
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var incident = await _context.Incidents.FirstOrDefaultAsync(i => i.Id == id);
        if (incident == null) return false;
        _context.Incidents.Remove(incident);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<List<IncidentDto>> FilterAsync(IncidentFilterDto filter)
    {
        var query = _context.Incidents.AsQueryable();
        if (filter.Status.HasValue)
            query = query.Where(i => i.Status == filter.Status.Value);
        if (filter.Severity.HasValue)
            query = query.Where(i => i.Severity == filter.Severity.Value);
        if (filter.Category.HasValue)
            query = query.Where(i => i.Category == filter.Category.Value);
        return await query.Select(i => new IncidentDto
        {
            Id = i.Id,
            Title = i.Title,
            Description = i.Description,
            Category = i.Category,
            Severity = i.Severity,
            Status = i.Status,
            CreatedAt = i.CreatedAt,
        }).ToListAsync();
    }
    public async Task<List<IncidentDto>> GetPagedAsync(PaginationDto pagination)
    {
        return await _context.Incidents.OrderByDescending(i => i.CreatedAt).Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).Select(i => new IncidentDto{Id = i.Id,Title = i.Title, Description = i.Description, Status = i.Status, Severity = i.Severity, Category = i.Category, CreatedAt = i.CreatedAt}).ToListAsync();
    }
}