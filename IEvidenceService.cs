using IncidentLog.DTOs.Evidence;

namespace IncidentLog.Interfaces;

public interface IEvidenceService
{
    Task<EvidenceDto> CreateAsync(Guid incidentId, CreateEvidenceDto dto);
    Task<List<EvidenceDto>> GetByIncidentAsync(Guid incidentId);
}