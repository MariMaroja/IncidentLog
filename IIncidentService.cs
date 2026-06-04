using IncidentLog.DTOs.Incident;
using IncidentLog.DTOs.Common;

namespace IncidentLog.Interfaces;

public interface IIncidentService
{
    Task<List<IncidentDto>> GetAllAsync();
    Task<IncidentDto?> GetByIdAsync(Guid id);
    Task<IncidentDto> CreateAsync(CreateIncidentDto dto);
    Task<IncidentDto?> UpdateAsync(Guid id, UpdateIncidentDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<List<IncidentDto>>FilterAsync(IncidentFilterDto filter);
    Task<List<IncidentDto>> GetPagedAsync(PaginationDto pagination);
}